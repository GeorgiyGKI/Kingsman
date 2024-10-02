using Shared.DTO;

namespace Service.Contracts;
public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByEmailAsync(string email);
}