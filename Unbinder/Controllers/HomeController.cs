using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Unbinder.Services;

namespace Unbinder.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var objects = await S3Service.ListObjects();

                if (objects != null)
                {
                    string keys = "";

                    foreach (var entry in objects.S3Objects)
                    {
                        keys += entry.Key + ", ";
                    }
                    
                    if (keys != "") logger.Log(LogLevel.Information, $"Found keys: {keys ?? "(none)"}");
                }
                else
                {
                    logger.Log(LogLevel.Debug, "Did not find results in S3");
                }
            }
            catch (Exception ex)
            {
                if (ex is AmazonS3Exception s3Exception)
                {
                    logger.Log(LogLevel.Warning, s3Exception.ErrorCode);
                    logger.Log(LogLevel.Warning, s3Exception.Message);
                }
                else
                logger.Log(LogLevel.Error, ex.Message);
            }

            return View();
        }
    }
}
