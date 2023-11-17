using Microsoft.AspNetCore.Mvc;
using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeApiController : BaseApiController<Recipe>
    {
        public RecipeApiController(IRecipeRepository recipeRepository) : base(recipeRepository)
        {
        }
    }
}
