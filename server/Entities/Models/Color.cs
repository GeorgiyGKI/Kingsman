using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Color
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Color name is a required field.")]
		[MaxLength(50, ErrorMessage = "Maximum length for the color name is 50 characters.")]
		public string Name { get; set; } // e.g "Red"

		[Required(ErrorMessage = "HEX value is a required field.")]
		[RegularExpression(@"^#([0-9a-fA-F]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Invalid HEX format.")]
		public string HexValue { get; set; } // e.g #FF0000

		[MaxLength(7, ErrorMessage = "Maximum length for RGB value is 7 characters.")]
		public string? RgbValue { get; set; } // RGB value in "R,G,B" format (e.g., "255,0,0")
        public ICollection<Product> Products { get; set; }
    }
}