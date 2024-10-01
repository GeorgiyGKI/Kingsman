using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record ColorForManipulationDto
{
    [Required(ErrorMessage = "Color name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the color name is 50 characters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "HEX value is a required field.")]
    [RegularExpression(@"^#([0-9a-fA-F]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Invalid HEX format.")]
    public string HexValue { get; init; }

    [MaxLength(7, ErrorMessage = "Maximum length for RGB value is 7 characters.")]
    public string? RgbValue { get; init; }
}
