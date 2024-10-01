using Entities.Models;

namespace Repository.Contracts;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges);
    Task<Order> GetOrderAsync(Guid orderId, bool trackChanges);
    void CreateOrder(Order order);
    Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteOrder(Order order);
}


