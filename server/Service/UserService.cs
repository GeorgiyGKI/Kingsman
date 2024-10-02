using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DTO;

namespace Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IRepositoryManager _repository;

    public UserService(IMapper mapper, UserManager<User> userManager, IRepositoryManager repository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userManager.Users
               .ToListAsync();

        ArgumentNullException.ThrowIfNull(users);

        var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

        return userDtos;
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        }

        var user = await _userManager.Users
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Email.Equals(email));

        ArgumentNullException.ThrowIfNull(user);

        var userDto = _mapper.Map<UserDto>(user);
        t
        return userDto;
    }
}