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

        public IActionResult RecipeId(int id)
        {
            var result = _recipeRepository.GetById(id);
            return result == null 
                ? NotFound() 
                : View(result);
        }

        public IActionResult Search(string query)
        {
            var result = _recipeRepository.GetAll?.Where(r => r.Name.Contains(query));
            return result == null 
                ? NotFound() 
                : View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
