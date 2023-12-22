using Data.Abstract;
using Data.Concrete;
using Data.Concrete.MongoDB.Contexts;
using Data.Concrete.MongoDB.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadServices(this IServiceCollection sc, IConfiguration config)
        {
            sc.AddSingleton<IClassMapping,ProductMap>();
            sc.AddSingleton<MongoRepositoryAppContext>(sp => {
                return new MongoRepositoryAppContext(config);
            });
            sc.AddSingleton<IProductService, ProductManager>();
            sc.AddSingleton<IUnitOfWork, UnitOfWork>();
            return sc;
        }
    }
}
