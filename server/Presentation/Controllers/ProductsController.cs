using Kingsman.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductsController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetProducts")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.ProductService.GetAllProductsAsync(trackChanges: false);

        return Ok(products);
    }

    [HttpGet("{id:guid}", Name = "ProductById")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = false)]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _service.ProductService.GetProductAsync(id, trackChanges: false);

        return Ok(product);
    }

    [HttpPost(Name = "CreateProduct")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateProduct([FromBody] ProductForManipulationDto manipulationDto)
    {
        var createdProduct = await _service.ProductService.CreateProductAsync(manipulationDto)
            ;
        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _service.ProductService.DeleteProductAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForManipulationDto product)
    {
        await _service.ProductService.UpdateProductAsync(id, product, trackChanges: true);

        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
