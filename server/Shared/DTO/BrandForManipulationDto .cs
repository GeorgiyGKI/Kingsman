using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record BrandForManipulationDto
{
    [Required(ErrorMessage = "Brand name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string Name { get; init; }

    [MaxLength(250, ErrorMessage = "Maximum length for the Description is 250 characters.")]
    public string Description { get; init; }
}
