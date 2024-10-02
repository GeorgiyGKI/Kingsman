using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class User : IdentityUser
{
	[Required(ErrorMessage = "First name is a required field.")]
	[MaxLength(50, ErrorMessage = "Maximum length for the First Name is 50 characters.")]
	public string? FirstName { get; set; }

	[Required(ErrorMessage = "Last name is a required field.")]
	[MaxLength(50, ErrorMessage = "Maximum length for the Last Name is 50 characters.")]
	public string? LastName { get; set; }

	public string? RefreshToken { get; set; }
	public DateTime RefreshTokenExpiryTime { get; set; }
    public ICollection<Order> Orders { get; set; }
}
