using Shared.Enums;

namespace Shared.DTO;

public record ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
    public Size Size { get; init; }
    public string RefNumber { get; init; }
    public int CategoryId { get; init; }
    public int BrandId { get; init; }
    public int ColorId { get; init; }
}
