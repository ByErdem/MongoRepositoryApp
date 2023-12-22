using Data.Abstract;
using Data.Concrete.MongoDB.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly MgProductRepository _productRepository;

        public UnitOfWork(IConfiguration config)
        {
            _config = config;
        }

        public IProductRepository Products => _productRepository ?? new MgProductRepository(_config);
    }
}
