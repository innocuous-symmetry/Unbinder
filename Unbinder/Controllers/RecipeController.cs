using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.Controllers
{
    public class RecipeController : BaseController<Recipe>
    {
        public RecipeController(IRecipeRepository recipeRepository) : base(recipeRepository)
        {
        }
    }
}
