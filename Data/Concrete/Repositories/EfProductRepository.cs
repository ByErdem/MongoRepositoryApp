using Data.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Data.Concrete.EntityFramework;
using Shared.Data.Concrete.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {
        }
    }
}
