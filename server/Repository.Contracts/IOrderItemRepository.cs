using Entities.Models;

namespace Repository.Contracts;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(bool trackChanges);
    Task<OrderItem> GetOrderItemAsync(Guid orderItemId, bool trackChanges);
    void CreateOrderItem(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteOrderItem(OrderItem orderItem);
}


