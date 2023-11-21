using Microsoft.AspNetCore.Mvc;
using Unbinder.Services;

namespace Unbinder.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var objects = await S3Service.ListObjects();

            if (objects != null)
            {
                foreach (var entry in objects.S3Objects)
                {
                    Console.WriteLine(entry.Key);
                }
            }
            else
            {
                Console.WriteLine("Did not find results in S3");
            }

            return View();
        }
    }
}
