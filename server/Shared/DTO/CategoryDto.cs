﻿namespace Shared.DTO;

public record CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<ProductDto> Products { get; init; }
}
