using Data.Abstract;
using Entity.Concrete;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.MongoDB.Mapping
{
    public class ProductMap:IClassMapping
    {
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
