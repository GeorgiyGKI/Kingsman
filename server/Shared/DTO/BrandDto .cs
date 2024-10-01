namespace Shared.DTO;

public record BrandDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public ICollection<ProductDto> Products { get; init; }
}
