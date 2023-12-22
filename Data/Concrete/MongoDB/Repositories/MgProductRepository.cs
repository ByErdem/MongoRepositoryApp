using Data.Abstract;
using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Shared.Data.Concrete.MongoDB;

namespace Data.Concrete.MongoDB.Repositories
{
    public class MgProductRepository : MongoEntityRepositoryBase<Product>, IProductRepository
    {
        public MgProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
