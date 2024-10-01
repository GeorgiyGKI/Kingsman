namespace Shared.DTO;

public record ColorDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string HexValue { get; init; }
    public string? RgbValue { get; init; }
    public ICollection<ProductDto> Products { get; init; }
}
