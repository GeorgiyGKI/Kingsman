using Shared.DTO;

namespace Service.Contracts;
public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(bool trackChanges);
    Task<OrderItemDto> GetOrderItemAsync(Guid id, bool trackChanges);
    Task<OrderItemDto> CreateOrderItemAsync(OrderItemForManipulationDto orderItem);
    Task<IEnumerable<OrderItemDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<OrderItemDto> orderItems, string ids)> CreateOrderItemCollectionAsync(IEnumerable<OrderItemForManipulationDto> orderItemCollection);
    Task DeleteOrderItemAsync(Guid orderItemId, bool trackChanges);
    Task UpdateOrderItemAsync(Guid orderItemId, OrderItemForManipulationDto orderItemForUpdate, bool trackChanges);
}
