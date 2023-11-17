using Microsoft.AspNetCore.Mvc;
using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.Controllers.Api
{
    [ApiController]
    public class RecipeApiController(IRecipeRepository _repository) : ControllerBase
    {
        private readonly IRecipeRepository repository = _repository;

        [HttpGet]
        [Route("/api/recipe/search")]
        public IActionResult Search([FromQuery] string? q)
        {
            if (q == null) return Ok(repository.GetAll);

            var result = repository.GetAll?.Where(r => r.Name.Contains(q, StringComparison.OrdinalIgnoreCase));

            return result == null
                ? NotFound()
                : Ok(result);
        }
    }
}
