using Data.Abstract;
using Data.Concrete.MongoDB.Repositories;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly ISessionFactory _sessionFactory;
        private readonly MgProductRepository _productRepository;
        private readonly NhProductRepository _nhProductRepository;

        public UnitOfWork(IConfiguration config, ISessionFactory sessionFactory)
        {
            _config = config;
            _sessionFactory = sessionFactory;
        }

        public IProductRepository MgProducts => _productRepository ?? new MgProductRepository(_config);
        public IProductRepository NhProducts => _nhProductRepository ?? new NhProductRepository(_sessionFactory);

    }
}
