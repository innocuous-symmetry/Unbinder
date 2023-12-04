using Microsoft.AspNetCore.Mvc;
using Unbinder.Repositories;

namespace Unbinder.Controllers
{
    public class RecipeIngredientController(IRecipeIngredientRepository repository) : Controller
    {
        private readonly IRecipeIngredientRepository _repository = repository;

        public IActionResult Index()
        {
            return View();
        }
    }
}
