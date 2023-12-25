using Entity.Concrete;
using Shared.Data.Abstract;

namespace Data.Abstract
{
    public interface IProductRepository:IEntityRepository<Product>
    {
    }
}
