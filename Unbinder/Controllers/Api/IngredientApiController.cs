using Microsoft.AspNetCore.Mvc;
using Unbinder.Repositories;

namespace Unbinder.Controllers.Api
{
    [ApiController]
    public class IngredientApiController(IIngredientRepository repository) : ControllerBase
    {
        private readonly IIngredientRepository _repository = repository;

        [HttpGet]
        [Route("/api/ingredients")]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll;
            return result == null ? NotFound() : Ok(result);
        }
    }
}