using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.MongoDB.Contexts
{
    public class MongoRepositoryAppContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public IMongoCollection<Product> Products => _mongoDatabase.GetCollection<Product>("Products");


        public MongoRepositoryAppContext(IConfiguration config)
        {
            var connectionString = "mongodb://hostname:27017/" + config["database"];
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(config["database"]);
        }
    }
}
