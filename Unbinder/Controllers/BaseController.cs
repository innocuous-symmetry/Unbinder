using Microsoft.AspNetCore.Mvc;
using Unbinder.Repositories;

namespace Unbinder.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll;
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id)
        {
            var result = _repository.UpdateById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _repository.DeleteById(id);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
