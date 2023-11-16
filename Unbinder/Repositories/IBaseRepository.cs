namespace Unbinder.Repositories
{
    public interface IBaseRepository<T>
    {
        public IEnumerable<T> GetAll { get; }
        public T? GetById(int id);
        public T? UpdateById(int id);
        public int DeleteById(int id);
    }
}
