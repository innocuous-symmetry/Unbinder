using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Unbinder.DB;

namespace Unbinder.Repositories
{
    public abstract class BaseRepository<T>(UnbinderDbContext dbContext) : IBaseRepository<T> where T : class
    {
        protected readonly UnbinderDbContext _dbContext = dbContext;

        public abstract IEnumerable<T>? GetAll { get; }

        public abstract T? GetById(int id);

        public abstract T? UpdateById(int id);
        public abstract T Post(T entity);

        public abstract int DeleteById(int id);
    }
}
