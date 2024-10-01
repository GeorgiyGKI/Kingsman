using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record CategoryForManipulationDto
{
    [Required(ErrorMessage = "Category name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string Name { get; init; }
}
