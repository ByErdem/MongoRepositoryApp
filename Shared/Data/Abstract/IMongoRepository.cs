using MongoDB.Entities;
using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Abstract
{
    public interface IMongoRepository<T> where T : class, IDBEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> UpdateAsync(T entity);
    }
}
