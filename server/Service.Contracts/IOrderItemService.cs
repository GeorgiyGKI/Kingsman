using Shared.DTO;

namespace Service.Contracts;
public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(Guid orderId, bool trackChanges);
    Task<OrderItemDto> GetOrderItemAsync(Guid orderId, Guid id, bool trackChanges);
    Task<OrderItemDto> CreateOrderItemAsync(Guid orderId, OrderItemForManipulationDto orderItem);
    Task<IEnumerable<OrderItemDto>> GetByIdsAsync(Guid orderId, IEnumerable<Guid> ids, bool trackChanges);
    Task DeleteOrderItemAsync(Guid orderId, Guid orderItemId, bool trackChanges);
    Task UpdateOrderItemAsync(Guid orderId, Guid orderItemId, OrderItemForManipulationDto orderItemForUpdate, bool trackChanges);
}
