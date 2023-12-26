namespace Data.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository MgProducts { get; }
        IProductRepository NhProducts { get; }
        IProductRepository EfProducts { get; }
    }
}
