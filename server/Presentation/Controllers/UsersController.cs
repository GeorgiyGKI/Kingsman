using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _service;

    public UsersController(IServiceManager service) => _service = service;

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _service.UserService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpGet("{email}", Name = "GetUserByEmail")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = false)]
    public async Task<IActionResult> GetUserById(string email)
    {
        var user = await _service.UserService.GetUserByEmailAsync(email);

        return Ok(user);
    }
}