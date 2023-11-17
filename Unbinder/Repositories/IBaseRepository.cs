using Unbinder.DB;

namespace Unbinder.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public IEnumerable<T>? GetAll { get; }
        public T? GetById(int id);
        public T? UpdateById(int id);
        public T Post(T entity);
        public int DeleteById(int id);
    }
}
