using Microsoft.AspNetCore.Mvc;
using Unbinder.Models;
using Unbinder.Repositories;
using Unbinder.ViewModels;

namespace Unbinder.Controllers
{
    public class RecipeController(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository) : Controller
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository = recipeIngredientRepository;

        public IActionResult Index()
        {
            var result = _recipeRepository.GetAll;
            return result == null
                ? NotFound()
                : View(result);
        }

        [Route("[controller]/{recipeId}")]
        public IActionResult RecipeId(int recipeId, bool editMode = false)
        {
            ViewBag.EditMode = editMode;

            var recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null) return NotFound();
            var ingredients = _recipeIngredientRepository.GetIngredientsByRecipeId(recipeId);



            RecipeViewModel recipeViewModel = new(recipe, ingredients);
            return View(recipeViewModel);
        }

        [Route("[controller]/search")]
        public IActionResult Search([FromQuery] string? q, [FromQuery] string? category)
        {
            if (q == null && category == null) return View(_recipeRepository.GetAll);

            var result = _recipeRepository.GetAll?.Where(r => r.Name.Contains(q!, StringComparison.OrdinalIgnoreCase));
            ViewBag.Query = q;

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
