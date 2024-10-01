using Kingsman.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IServiceManager _service;

    public OrdersController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetOrders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _service.OrderService.GetAllOrdersAsync(trackChanges: false);

        return Ok(orders);
    }

    [HttpGet("{id:guid}", Name = "OrderById")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);

        return Ok(order);
    }

    [HttpPost(Name = "CreateOrder")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateOrder([FromBody] OrderForManipulationDto manipulationDto)
    {
        var createdOrder = await _service.OrderService.CreateOrderAsync(manipulationDto);

        return CreatedAtRoute("OrderById", new { id = createdOrder.Id }, createdOrder);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        await _service.OrderService.DeleteOrderAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderForManipulationDto order)
    {
        await _service.OrderService.UpdateOrderAsync(id, order, trackChanges: true)
            ;
        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
