using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using Unbinder.Services;

namespace Unbinder.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                S3Service s3Service = new();
                var response = await s3Service.ListObjects();

                if (response == null)
                {
                    logger.Log(LogLevel.Debug, "Did not find results in S3");
                    return View();
                }

                string keys = "";
                foreach (var entry in response.S3Objects)
                {
                    keys += entry.Key + ", ";
                }
                    
                if (keys != "") logger.Log(LogLevel.Information, $"Found keys: {keys ?? "(none)"}");
                return View(response.S3Objects);
            }
            catch (Exception ex)
            {
                HandleError(ex, logger);
                return View();
            }
        }

        private static void HandleError(Exception ex, ILogger logger)
        {
            if (ex is AmazonS3Exception s3Exception)
            {
                logger.Log(LogLevel.Warning, s3Exception.ErrorCode);
                logger.Log(LogLevel.Warning, s3Exception.Message);
            }
            else
                logger.Log(LogLevel.Error, ex.Message);
        }
    }
}
