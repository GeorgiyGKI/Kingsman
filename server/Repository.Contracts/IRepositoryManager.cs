using Repository.Contracts;

namespace Contracts;

public interface IRepositoryManager
{
    ICategoryRepository Category { get; }
    IColorRepository Color { get; }
    ICustomerRepository Customer { get; }
    IOrderRepository Order { get; }
    IOrderItemRepository OrderItem { get; }
    IProductRepository Product { get; }
    IBrandRepository Brand { get; }
    Task SaveAsync();
}