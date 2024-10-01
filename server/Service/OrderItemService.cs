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

    public async Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(bool trackChanges)
    {
        var orderItems = await _repository.OrderItem.GetAllOrderItemsAsync(trackChanges);

        var orderItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);

        return orderItemsDto;
    }

    public async Task<OrderItemDto> GetOrderItemAsync(Guid id, bool trackChanges)
    {
        var orderItem = await GetOrderItemAndCheckIfItExists(id, trackChanges);

        var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);

        return orderItemDto;
    }

    public async Task<OrderItemDto> CreateOrderItemAsync(OrderItemForManipulationDto orderItem)
    {
        var orderItemEntity = _mapper.Map<OrderItem>(orderItem);

        _repository.OrderItem.CreateOrderItem(orderItemEntity);
        await _repository.SaveAsync();

        var orderItemToReturn = _mapper.Map<OrderItemDto>(orderItemEntity);

        return orderItemToReturn;
    }

    public async Task<IEnumerable<OrderItemDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var orderItemEntities = await _repository.OrderItem.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != orderItemEntities.Count())
            throw new ArgumentOutOfRangeException();

        var orderItemsToReturn = _mapper.Map<IEnumerable<OrderItemDto>>(orderItemEntities);

        return orderItemsToReturn;
    }

    public async Task<(IEnumerable<OrderItemDto> orderItems, string ids)> CreateOrderItemCollectionAsync
        (IEnumerable<OrderItemForManipulationDto> orderItemCollection)
    {
        ArgumentNullException.ThrowIfNull(orderItemCollection);

        var orderItemEntities = _mapper.Map<IEnumerable<OrderItem>>(orderItemCollection);
        foreach (var orderItem in orderItemEntities)
        {
            _repository.OrderItem.CreateOrderItem(orderItem);
        }

        await _repository.SaveAsync();

        var orderItemCollectionToReturn = _mapper.Map<IEnumerable<OrderItemDto>>(orderItemEntities);
        var ids = string.Join(",", orderItemCollectionToReturn.Select(c => c.Id));

        return (orderItems: orderItemCollectionToReturn, ids);
    }

    public async Task DeleteOrderItemAsync(Guid orderItemId, bool trackChanges)
    {
        var orderItem = await GetOrderItemAndCheckIfItExists(orderItemId, trackChanges);

        _repository.OrderItem.DeleteOrderItem(orderItem);

        await _repository.SaveAsync();
    }

    public async Task UpdateOrderItemAsync(
        Guid orderItemId,
        OrderItemForManipulationDto orderItemForUpdate,
        bool trackChanges)
    {
        var orderItem = await GetOrderItemAndCheckIfItExists(orderItemId, trackChanges);

        _mapper.Map(orderItemForUpdate, orderItem);

        await _repository.SaveAsync();
    }

    private async Task<OrderItem> GetOrderItemAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var orderItem = await _repository.OrderItem.GetOrderItemAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(orderItem);

        return orderItem;
    }
}
