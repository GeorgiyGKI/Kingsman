using Kingsman.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoriesController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);

        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "CategoryById")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = false)]
    public async Task<IActionResult> GetCategory(int id)

    {
        var category = await _service.CategoryService.GetCategoryAsync(id, trackChanges: false);

        return Ok(category);
    }

    [HttpPost(Name = "CreateCategory")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForManipulationDto manipulationDto)
    {
        var createdCategory = await _service.CategoryService.CreateCategoryAsync(manipulationDto);

        return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _service.CategoryService.DeleteCategoryAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryForManipulationDto category)
    {
        await _service.CategoryService.UpdateCategoryAsync(id, category, trackChanges: true);

        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
