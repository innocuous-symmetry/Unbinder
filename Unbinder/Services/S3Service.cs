using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using System.Net;
using Amazon.S3.Model;

namespace Unbinder.Services
{
    public sealed class S3Service
    {
        private static AWSCredentials Credentials
        {
            get
            {
                string? accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
                string? secret = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");

                if (accessKey == null || secret == null)
                {
                    throw new Exception("AWS credentials not found");
                }

                return new BasicAWSCredentials(accessKey, secret);
            }
        }

        private static AmazonS3Config Config => new()
        {
            RegionEndpoint = RegionEndpoint.USEast2
        };

        private static AmazonS3Client Client => new(Credentials, Config);
        private static readonly AmazonS3Client client = Client;
        private static readonly string? BucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME");

        public static async Task<ListObjectsResponse> ListObjects(string? prefix = "")
        {
            var bucketName = BucketName;
            var request = new ListObjectsRequest
            {
                BucketName = bucketName,
                Prefix = prefix
            };

            return await client.ListObjectsAsync(request);
        }

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var bucketName = "unbinder-recipe-images";
            var keyName = file.FileName;

            using var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(file.OpenReadStream(), bucketName, keyName);

            return keyName;
        }

        public async Task GetFile(string path, string outFile)
        {
            var bucketName = "unbinder-recipe-images";
            using var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.DownloadAsync(outFile, bucketName, path);
        }
    }
}
