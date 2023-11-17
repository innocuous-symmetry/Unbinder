using Microsoft.AspNetCore.Mvc;
using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.Controllers
{
    public class RecipeController(IRecipeRepository recipeRepository) : Controller
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;

        public IActionResult Index()
        {
            var result = _recipeRepository.GetAll;
            return result == null
                ? NotFound()
                : View(result);
        }

        [Route("[controller]/{id}")]
        public IActionResult RecipeId(int id)
        {
            var result = _recipeRepository.GetById(id);

            Console.WriteLine(result == null ? "No result found" : result);

            return result == null
                ? NotFound()
                : View(result);
        }

        [Route("[controller]/search")]
        public IActionResult Search([FromQuery] string? q, string? category)
        {
            if (q == null && category == null) return View(_recipeRepository.GetAll);

            var result = _recipeRepository.GetAll?.Where(r => r.Name.Contains(q, StringComparison.OrdinalIgnoreCase));

            return result == null 
                ? NotFound() 
                : View(result);
        }

        [HttpGet]
        [Route("[controller]/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var result = _recipeRepository.Post(recipe);
                return result == null 
                    ? BadRequest() 
                    : RedirectToAction("RecipeId", new { id = result.RecipeId });
            }
            return BadRequest();
        }
    }
}
