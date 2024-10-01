namespace Shared.DTO;

public record CustomerDto
{
    public string Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string? RefreshToken { get; init; }
    public DateTime RefreshTokenExpiryTime { get; init; }
    public ICollection<OrderItemDto> OrderItems { get; init; }
}
