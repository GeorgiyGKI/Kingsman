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

    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(oi => oi.Quantity)
        .ToListAsync();

    public async Task<OrderItem> GetOrderItemAsync(Guid orderItemId, bool trackChanges) =>
        await FindByCondition(oi => oi.Id.Equals(orderItemId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateOrderItem(OrderItem orderItem) => Create(orderItem);

    public async Task<IEnumerable<OrderItem>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToListAsync();

    public void DeleteOrderItem(OrderItem orderItem) => Delete(orderItem);
}


