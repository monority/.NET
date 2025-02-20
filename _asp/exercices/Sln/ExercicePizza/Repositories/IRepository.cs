using System.Linq.Expressions;
using ExercicePizza.Models;

namespace ExercicePizza.Repositories;

public interface IRepository<T, Tid> where T : new()
{
    Task<T> Add(T entity);
    Task<T?> GetById(Tid id);
    Task<T?> Get(Expression<Func<Pizza, bool>> predicate);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Expression<Func<Pizza, bool>> predicate);
    Task<T?> Update(T entity);
    Task<bool> Delete(Tid id);
}
