using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record UserDto
{
    public string Id { get; init; }
    public string? FirstName { get; set; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? RefreshToken { get; init; }
    public DateTime RefreshTokenExpiryTime { get; init; }
    public ICollection<Order> Orders { get; init; }
}