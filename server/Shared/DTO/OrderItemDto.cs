namespace Shared.DTO;

public record OrderItemDto
{
    public Guid Id { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public Guid ProductId { get; init; }
}
