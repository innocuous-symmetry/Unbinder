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
        private static AmazonS3Client CreateClient()
        {
            return new AmazonS3Client(Credentials, Config);
        }

        private static AWSCredentials Credentials
        {
            get
            {
                string accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY") ?? throw new Exception("AWS credentials not found");
                string secret = Environment.GetEnvironmentVariable("AWS_SECRET_KEY") ?? throw new Exception("AWS credentials not found");
                return new BasicAWSCredentials(accessKey, secret);
            }
        }

        private static AmazonS3Config Config => new()
        {
            RegionEndpoint = RegionEndpoint.USEast2
        };

        private static readonly string BucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME") ?? throw new Exception("AWS_BUCKET_NAME is not defined");

        public async Task<ListObjectsResponse> ListObjects(string? prefix = "")
        {
            using var _client = CreateClient();
            var request = new ListObjectsRequest
            {
                BucketName = BucketName,
                Prefix = prefix
            };

            return await _client.ListObjectsAsync(request);
        }

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            using var _client = CreateClient();
            using var fileTransferUtility = new TransferUtility(_client);

            await fileTransferUtility.UploadAsync(
                /** Stream stream, string bucketName, string key */
                file.OpenReadStream(), BucketName, file.FileName);

            return file.FileName;
        }

        public async Task GetFile(string path, string outFile)
        {
            using var _client = CreateClient();
            using var fileTransferUtility = new TransferUtility(_client);
            await fileTransferUtility.DownloadAsync(outFile, BucketName, path);
        }
    }
}
