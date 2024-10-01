using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record CustomerForManipulationDto
{
    [Required(ErrorMessage = "First name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the First Name is 50 characters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Last Name is 50 characters.")]
    public string LastName { get; init; }

    public string? RefreshToken { get; init; }
    public DateTime RefreshTokenExpiryTime { get; init; }
}
