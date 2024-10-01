using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service;

internal sealed class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public OrderService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges)
    {
        var orders = await _repository.Order.GetAllOrdersAsync(trackChanges);

        var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

        return ordersDto;
    }

    public async Task<OrderDto> GetOrderAsync(Guid id, bool trackChanges)
    {
        var order = await GetOrderAndCheckIfItExists(id, trackChanges);

        var orderDto = _mapper.Map<OrderDto>(order);

        return orderDto;
    }

    public async Task<OrderDto> CreateOrderAsync(OrderForManipulationDto order)
    {
        var orderEntity = _mapper.Map<Order>(order);

        _repository.Order.CreateOrder(orderEntity);
        await _repository.SaveAsync();

        var orderToReturn = _mapper.Map<OrderDto>(orderEntity);

        return orderToReturn;
    }

    public async Task<IEnumerable<OrderDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var orderEntities = await _repository.Order.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != orderEntities.Count())
            throw new ArgumentOutOfRangeException();

        var ordersToReturn = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);

        return ordersToReturn;
    }

    public async Task<(IEnumerable<OrderDto> orders, string ids)> CreateOrderCollectionAsync
        (IEnumerable<OrderForManipulationDto> orderCollection)
    {
        ArgumentNullException.ThrowIfNull(orderCollection);

        var orderEntities = _mapper.Map<IEnumerable<Order>>(orderCollection);
        foreach (var order in orderEntities)
        {
            _repository.Order.CreateOrder(order);
        }

        await _repository.SaveAsync();

        var orderCollectionToReturn = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);
        var ids = string.Join(",", orderCollectionToReturn.Select(c => c.Id));

        return (orders: orderCollectionToReturn, ids);
    }

    public async Task DeleteOrderAsync(Guid orderId, bool trackChanges)
    {
        var order = await GetOrderAndCheckIfItExists(orderId, trackChanges);

        _repository.Order.DeleteOrder(order);

        await _repository.SaveAsync();
    }

    public async Task UpdateOrderAsync(
        Guid orderId,
        OrderForManipulationDto orderForUpdate,
        bool trackChanges)
    {
        var order = await GetOrderAndCheckIfItExists(orderId, trackChanges);

        _mapper.Map(orderForUpdate, order);

        await _repository.SaveAsync();
    }

    private async Task<Order> GetOrderAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var order = await _repository.Order.GetOrderAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(order);

        return order;
    }
}
