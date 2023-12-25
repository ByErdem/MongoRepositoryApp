using Data.Abstract;
using Entity.Concrete;
using NHibernate;
using Shared.Data.Concrete.NHibernate;

namespace Data.Concrete.MongoDB.Repositories
{
    public class NhProductRepository : NhEntityRepositoryBase<Product>, IProductRepository
    {
        public NhProductRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}
