using Data.Abstract;
using Entity.Concrete;
using FluentNHibernate.Mapping;

namespace Data.Concrete.Mapping.NHibernate
{
    public class NhProductMap : ClassMap<Product>, IClassMapping
    {
        public NhProductMap()
        {
            RegisterMappings();
        }

        public void RegisterMappings()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(250);
            Map(x => x.Quantity);
            Map(x => x.Value);
            Table("Products");
        }
    }
}
