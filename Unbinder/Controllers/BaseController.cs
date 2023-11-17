using Microsoft.AspNetCore.Mvc;
using Unbinder.Repositories;

namespace Unbinder.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected readonly IBaseRepository<T> repository;

        public BaseController(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public IActionResult GetAll()
        {
            var result = repository.GetAll;
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        public IActionResult GetById(int id)
        {
            var result = repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // mutators exposed in API controller, intended to be called from front end
    }
}
