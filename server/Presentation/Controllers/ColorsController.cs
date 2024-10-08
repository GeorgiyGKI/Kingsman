﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Marvin.Cache.Headers;
using Kingsman.Presentation.ActionFilters;
using Shared.DTO;
using Kingsman.Server.Presentation.ModelBinders;

namespace ColorEmployees.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
//[ResponseCache(CacheProfileName = "120SecondsDuration")]
public class ColorsController : ControllerBase
{
	private readonly IServiceManager _service;

	public ColorsController(IServiceManager service) => _service = service;

	/// <summary>
	/// Gets the list of all companies
	/// </summary>
	/// <returns>The companies list</returns>
	[HttpGet(Name = "GetColors")]
	public async Task<IActionResult> GetColors()
	{
		var companies = await _service.ColorService.GetAllColorsAsync(trackChanges: false);

		return Ok(companies);
	}

	[HttpGet("{id:int}", Name = "ColorById")]
	[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
	[HttpCacheValidation(MustRevalidate = false)]
	public async Task<IActionResult> GetColor(int id)
	{
		var color = await _service.ColorService.GetColorAsync(id, trackChanges: false);

		return Ok(color);
	}

	[HttpGet("collection/({ids})", Name = "ColorCollection")]
	public async Task<IActionResult> GetColorCollection
		([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
	{
		var companies = await _service.ColorService.GetByIdsAsync(ids, trackChanges: false);

		return Ok(companies);
	}

	/// <summary>
	/// Creates a newly created color
	/// </summary>
	/// <param name="color"></param>
	/// <returns>A newly created color</returns>
	/// <response code="201">Returns the newly created item</response>
	/// <response code="400">If the item is null</response>
	/// <response code="422">If the model is invalid</response>
	[HttpPost(Name = "CreateColor")]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(422)]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateColor([FromBody] ColorForManipulationDto manipulationDto)
	{
		var createdColor = await _service.ColorService.CreateColorAsync(manipulationDto);

		return CreatedAtRoute("ColorById", new { id = createdColor.Id }, createdColor);
	}

	[HttpPost("collection")]
	public async Task<IActionResult> CreateColorCollection
		([FromBody] IEnumerable<ColorForManipulationDto> colorCollection)
	{
		var (colors, ids) = await _service.ColorService.CreateColorCollectionAsync(colorCollection);

		return CreatedAtRoute("ColorCollection", new { ids }, colors);
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> DeleteColor(int id)
	{
		await _service.ColorService.DeleteColorAsync(id, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{id:int}")]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	public async Task<IActionResult> UpdateColor(int id, [FromBody] ColorForManipulationDto color)
	{
		await _service.ColorService.UpdateColorAsync(id, color, trackChanges: true);

		return NoContent();
	}

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

        return Ok();
    }
}
