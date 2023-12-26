using Data.Abstract;
using Data.Concrete.Contexts;
using Data.Concrete.Repositories;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly ISessionFactory _sessionFactory;
        private readonly EfContext _context;
        private readonly MgProductRepository _mgProductRepository;
        private readonly NhProductRepository _nhProductRepository;
        private readonly EfProductRepository _efProductRepository;

        public UnitOfWork(IConfiguration config, ISessionFactory sessionFactory, EfContext context)
        {
            _config = config;
            _sessionFactory = sessionFactory;
            _context = context;
        }

        public IProductRepository MgProducts => _mgProductRepository ?? new MgProductRepository(_config);
        public IProductRepository NhProducts => _nhProductRepository ?? new NhProductRepository(_sessionFactory);
        public IProductRepository EfProducts => _efProductRepository ?? new EfProductRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
