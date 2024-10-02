namespace Shared.DTO;

public record OrderDto
{
    public Guid Id { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal TotalAmount { get; init; }
    public string UserId { get; init; }
    public ICollection<OrderItemDto> OrderItems { get; init; }
}
