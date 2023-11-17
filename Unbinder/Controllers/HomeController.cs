using Microsoft.AspNetCore.Mvc;

namespace Unbinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
