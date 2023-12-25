using Data.Abstract;
using Data.Concrete;
using Data.Concrete.MongoDB.Mapping.Mongo;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;

namespace Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadServices(this IServiceCollection sc, IConfiguration config)
        {
            sc.AddSingleton<IProductService, ProductManager>();
            sc.AddSingleton<IUnitOfWork, UnitOfWork>();

            #region Mongo Settings
            sc.AddSingleton<IClassMapping, MgProductMap>();
            #endregion

            #region NHibernate Settings

            // NHibernate ISessionFactory yapılandırması
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(config["NHibernate:ConnectionString"])) // Connection string appsettings.json'dan alınır
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MgProductMap>()) // ProductMap veya diğer mapping sınıflarınız
                .BuildSessionFactory();

            // ISessionFactory'yi servis konteynerine singleton olarak ekleyin
            sc.AddSingleton(sessionFactory);

            // İsteğe bağlı olarak, ISession'ı da her istekte bir olarak ekleyebilirsiniz
            sc.AddScoped(factory => sessionFactory.OpenSession());

            #endregion

            return sc;
        }
    }
}
