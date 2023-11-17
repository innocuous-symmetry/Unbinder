using Microsoft.AspNetCore.Mvc;
using Unbinder.Repositories;

namespace Unbinder.Controllers.Api
{
    public abstract class BaseApiController<T> : ControllerBase
    {
        protected readonly IBaseRepository<T> repository;

        public BaseApiController(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public IActionResult UpdateById(int id)
        {
            var result = repository.UpdateById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = repository.DeleteById(id);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
