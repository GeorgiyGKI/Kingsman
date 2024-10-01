using Entities.Enums;
using Entities.Models;

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
    public CategoryDto Category { get; init; }
    public BrandDto Brand { get; init; }
    public ColorDto Color { get; init; }
}
