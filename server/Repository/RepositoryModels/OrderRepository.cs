using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.RepositoryModels;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(o => o.OrderDate)
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
        .ToListAsync();

    public async Task<Order> GetOrderAsync(Guid orderId, bool trackChanges) =>
        await FindByCondition(o => o.Id.Equals(orderId), trackChanges)
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
        .SingleOrDefaultAsync();

    public void CreateOrder(Order order) => Create(order);

    public async Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
        .ToListAsync();

    public void DeleteOrder(Order order) => Delete(order);
}


