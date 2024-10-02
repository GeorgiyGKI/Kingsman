using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.RepositoryModels;

internal sealed class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(Guid orderId, bool trackChanges) =>
        await FindByCondition(oi => oi.OrderId.Equals(orderId), trackChanges)
        .OrderBy(oi => oi.Quantity)
        .ToListAsync();

    public async Task<OrderItem> GetOrderItemAsync(Guid orderId, Guid orderItemId, bool trackChanges) =>
        await FindByCondition
        (
            oi => oi.OrderId.Equals(orderId) &&
            oi.Id.Equals(orderItemId),
            trackChanges
        )
        .SingleOrDefaultAsync();

    public void CreateOrderItem(Guid orderId, OrderItem orderItem) {
        orderItem.OrderId = orderId;
        Create(orderItem);
    }

    public async Task<IEnumerable<OrderItem>> GetByIdsAsync(Guid orderId, IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(oi => oi.OrderId.Equals(orderId) && ids.Contains(oi.Id), trackChanges)
        .ToListAsync();

    public void DeleteOrderItem(OrderItem orderItem) => Delete(orderItem);
}