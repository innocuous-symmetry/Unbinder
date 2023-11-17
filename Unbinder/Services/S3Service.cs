using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;

namespace Unbinder.Services
{
    public class S3Service
    {
        public static AWSCredentials Credentials => 
            new BasicAWSCredentials(
                Environment.GetEnvironmentVariable("AWS_ACCESS_KEY"),
                Environment.GetEnvironmentVariable("AWS_SECRET_KEY"));

        public static AmazonS3Client Client => new(Credentials, RegionEndpoint.USEast1);

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            using IAmazonS3 client = Client;

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
            using IAmazonS3 client = Client;

            var bucketName = "unbinder-recipe-images";
            using var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.DownloadAsync(outFile, bucketName, path);
        }
    }
}
