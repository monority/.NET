using System.Linq.Expressions;

namespace Exercice_Api.Models
{
    public interface IRepository<T> where T : class
    {
        public T Add(T entity);

        public T? Get(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        public T? GetById(int id);
        public T? FilterBy(T entity);
        public T? GetByName(string lastName);
        public T? Update(T entity);
        public bool Delete(int id);
    }
}
