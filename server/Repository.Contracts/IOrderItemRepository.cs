using Entities.Models;

namespace Repository.Contracts;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(Guid orderId, bool trackChanges);
    Task<OrderItem> GetOrderItemAsync(Guid orderId, Guid orderItemId, bool trackChanges);
    void CreateOrderItem(Guid orderId, OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetByIdsAsync(Guid orderId, IEnumerable<Guid> ids, bool trackChanges);
    void DeleteOrderItem(OrderItem orderItem);
}


