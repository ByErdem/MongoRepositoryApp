using NHibernate;
using NHibernate.Linq;
using Shared.Data.Abstract;
using Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace Shared.Data.Concrete.NHibernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IDBEntity, new()
    {
        private readonly ISessionFactory _sessionFactory;

        public NhEntityRepositoryBase(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            await session.SaveAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using var session = _sessionFactory.OpenSession();
            return await session.Query<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using var session = _sessionFactory.OpenSession();
            return await session.Query<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            await session.DeleteAsync(entity);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            using var session = _sessionFactory.OpenSession();
            var query = session.Query<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using var session = _sessionFactory.OpenSession();
            return await session.Query<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return null;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            await session.UpdateAsync(entity);
            return entity;
        }
    }
}