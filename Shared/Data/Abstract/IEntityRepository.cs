using Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IDBEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> UpdateAsync(T entity);
    }
}
