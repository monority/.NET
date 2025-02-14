namespace Exercice06.Models
{
    public interface IRepository<T> where T : class
    {
        public T Create(T entity);
        public IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        public T? GetById(int id);
        public T? Update(T entity);
        public bool Delete(T entity);
    }
}
