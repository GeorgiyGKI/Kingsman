using Kingsman.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IServiceManager _service;

    public BrandsController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetBrands")]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _service.BrandService.GetAllBrandsAsync(trackChanges: false);

        return Ok(brands);
    }

    [HttpGet("{id:int}", Name = "BrandById")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = false)]
    public async Task<IActionResult> GetBrand(int id)
    {
        var brand = await _service.BrandService.GetBrandAsync(id, trackChanges: false);

        return Ok(brand);
    }

    [HttpPost(Name = "CreateBrand")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateBrand([FromBody] BrandForManipulationDto manipulationDto)
    {
        var createdBrand = await _service.BrandService.CreateBrandAsync(manipulationDto);

        return CreatedAtRoute("BrandById", new { id = createdBrand.Id }, createdBrand);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        await _service.BrandService.DeleteBrandAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandForManipulationDto brand)
    {
        await _service.BrandService.UpdateBrandAsync(id, brand, trackChanges: true);

        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
