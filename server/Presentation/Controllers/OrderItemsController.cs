using Entities.Models;
using Kingsman.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

[Route("api/Orders/{orderId:guid}/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IServiceManager _service;

    public OrderItemsController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetOrderItems")]
    public async Task<IActionResult> GetOrderItems(Guid orderId)
    {
        var orderItems = await _service.OrderItemService.GetAllOrderItemsAsync(orderId, trackChanges: false);

        return Ok(orderItems);
    }

    [HttpGet("{id:guid}", Name = "OrderItemById")]
    public async Task<IActionResult> GetOrderItem(Guid orderId, Guid id)
    {
        var orderItem = await _service.OrderItemService.GetOrderItemAsync(orderId, id, trackChanges: false);

        return Ok(orderItem);
    }

    [HttpPost(Name = "CreateOrderItem")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateOrderItem(Guid orderId, [FromBody] OrderItemForManipulationDto manipulationDto)
    {
        var createdOrderItem = await _service.OrderItemService.CreateOrderItemAsync(orderId, manipulationDto);

        return CreatedAtRoute("OrderItemById", new { id = createdOrderItem.Id }, createdOrderItem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrderItem(Guid orderId, Guid id)
    {
        await _service.OrderItemService.DeleteOrderItemAsync(orderId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOrderItem(
        Guid orderId,
        Guid id,
        [FromBody] OrderItemForManipulationDto orderItem
        )
    {
        await _service.OrderItemService.UpdateOrderItemAsync(orderId, id, orderItem, trackChanges: true);

        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
