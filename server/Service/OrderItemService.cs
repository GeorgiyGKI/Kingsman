using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service;

internal sealed class OrderItemService : IOrderItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public OrderItemService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(Guid orderId, bool trackChanges)
    {
        await CheckIfOrderExists(orderId, false);

        var orderItems = await _repository.OrderItem.GetAllOrderItemsAsync(orderId, trackChanges);

        var orderItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);

        return orderItemsDto;
    }

    public async Task<OrderItemDto> GetOrderItemAsync(Guid orderId, Guid id, bool trackChanges)
    {
        await CheckIfOrderExists(orderId, false);

        var orderItem = await GetOrderItemAndForOrderCheckIfItExists(orderId, id, trackChanges);

        var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);

        return orderItemDto;
    }

    public async Task<OrderItemDto> CreateOrderItemAsync(Guid orderId,OrderItemForManipulationDto orderItem)
    {
        await CheckIfOrderExists(orderId, false);

        var orderItemEntity = _mapper.Map<OrderItem>(orderItem);

        _repository.OrderItem.CreateOrderItem(orderId, orderItemEntity);
        await _repository.SaveAsync();

        var orderItemToReturn = _mapper.Map<OrderItemDto>(orderItemEntity);

        return orderItemToReturn;
    }

    public async Task<IEnumerable<OrderItemDto>> GetByIdsAsync(
        Guid orderId,
        IEnumerable<Guid> ids,
        bool trackChanges
        )
    {
        await CheckIfOrderExists(orderId, false);
        ArgumentNullException.ThrowIfNull(ids);

        var orderItemEntities = await _repository.OrderItem.GetByIdsAsync(orderId, ids, trackChanges);
        if (ids.Count() != orderItemEntities.Count())
            throw new ArgumentOutOfRangeException();

        var orderItemsToReturn = _mapper.Map<IEnumerable<OrderItemDto>>(orderItemEntities);

        return orderItemsToReturn;
    }

    public async Task DeleteOrderItemAsync(Guid orderId, Guid orderItemId, bool trackChanges)
    {
        await CheckIfOrderExists(orderId, false);

        var orderItem = await GetOrderItemAndForOrderCheckIfItExists(orderId, orderItemId, trackChanges);

        _repository.OrderItem.DeleteOrderItem(orderItem);

        await _repository.SaveAsync();
    }

    public async Task UpdateOrderItemAsync(
        Guid orderId,
        Guid orderItemId,
        OrderItemForManipulationDto orderItemForUpdate,
        bool trackChanges
        )
    {
        var orderItem = await GetOrderItemAndForOrderCheckIfItExists(orderId, orderItemId, trackChanges);

        _mapper.Map(orderItemForUpdate, orderItem);

        await _repository.SaveAsync();
    }

    private async Task<Order> CheckIfOrderExists(Guid id, bool trackChanges)
    {
        var order = await _repository.Order.GetOrderAsync(id, trackChanges);

        ArgumentNullException.ThrowIfNull(order);

        return order;
    }

    private async Task<OrderItem> GetOrderItemAndForOrderCheckIfItExists(Guid OrderId, Guid id, bool trackChanges)
    {
        var orderItem = await _repository.OrderItem.GetOrderItemAsync(OrderId, id, trackChanges);

        ArgumentNullException.ThrowIfNull(orderItem);

        return orderItem;
    }
}
