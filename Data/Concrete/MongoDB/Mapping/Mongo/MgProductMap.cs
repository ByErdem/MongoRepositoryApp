using Data.Abstract;
using Entity.Concrete;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Data.Concrete.MongoDB.Mapping.Mongo
{
    public class MgProductMap : IClassMapping
    {
        public MgProductMap()
        {
            RegisterMappings();
        }

        public void RegisterMappings()
        {
            BsonClassMap.RegisterClassMap<Product>(x =>
            {
                x.AutoMap();
                x.MapIdMember(c => c.Id)
                 .SetIdGenerator(GuidGenerator.Instance)
                 .SetSerializer(new GuidSerializer(BsonType.String))
                 .SetIsRequired(true);
                x.MapMember(x => x.Name).SetIsRequired(true);
            });
        }
    }
}
