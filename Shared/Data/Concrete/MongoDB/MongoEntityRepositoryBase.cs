using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared.Data.Abstract;
using Shared.Entities.Abstract;
using System.Linq.Expressions;


namespace Shared.Data.Concrete.MongoDB
{
    public class MongoEntityRepositoryBase<TEntity> : IMongoRepository<TEntity>
        where TEntity : class, IDBEntity, new()
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<TEntity> _entity;

        public MongoEntityRepositoryBase(IConfiguration configuration)
        {
            _config = configuration;
            Type genericType = typeof(TEntity);

            var collectionName = genericType.Name;
            var server = _config["Mongo:MongoDBServer"];
            var databaseName = _config["Mongo:MongoDatabaseName"];

            var client = new MongoClient(server);
            var database = client.GetDatabase(databaseName);
            _entity = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entity.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var cursor = await _entity.FindAsync(predicate);
            return await cursor.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var count = await _entity.CountDocumentsAsync(predicate);
            return (int)count;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var idProperty = typeof(TEntity).GetProperty("Id") ?? typeof(TEntity).GetProperty("_id");
            if (idProperty == null)
            {
                throw new InvalidOperationException("The TEntity type does not have an 'Id' or '_id' property.");
            }
            var idValue = idProperty.GetValue(entity);
            var filter = Builders<TEntity>.Filter.Eq("_id", idValue);
            await _entity.DeleteOneAsync(filter);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            // Filtre verilmemişse tüm belgeleri getirir.
            var filter = predicate ?? Builders<TEntity>.Filter.Empty;

            // Filtre uygulanarak belgeler bulunur.
            var findFluent = _entity.Find(filter);

            // Bulunan belgeler bir listeye dönüştürülerek döndürülür.
            return await findFluent.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var idProperty = typeof(TEntity).GetProperty("Id") ?? typeof(TEntity).GetProperty("_id");
            if (idProperty == null)
            {
                throw new InvalidOperationException("The TEntity type does not have an 'Id' or '_id' property.");
            }
            var idValue = idProperty.GetValue(entity);
            var filter = Builders<TEntity>.Filter.Eq("_id", idValue);
            await _entity.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
            return entity;
        }

    }
}
