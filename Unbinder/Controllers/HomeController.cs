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

                return View(response.S3Objects);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
                return View();
            }
        }
    }
}
