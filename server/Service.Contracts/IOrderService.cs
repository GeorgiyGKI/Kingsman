using Shared.DTO;

namespace Service.Contracts;
public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges);
    Task<OrderDto> GetOrderAsync(Guid id, bool trackChanges);
    Task<OrderDto> CreateOrderAsync(OrderForManipulationDto order);
    Task<IEnumerable<OrderDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<OrderDto> orders, string ids)> CreateOrderCollectionAsync(IEnumerable<OrderForManipulationDto> orderCollection);
    Task DeleteOrderAsync(Guid orderId, bool trackChanges);
    Task UpdateOrderAsync(Guid orderId, OrderForManipulationDto orderForUpdate, bool trackChanges);
}
