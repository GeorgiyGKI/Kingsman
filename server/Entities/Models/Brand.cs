using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class Brand
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Brand name is a required field.")]
		[MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
		public string Name { get; set; }

		[MaxLength(250, ErrorMessage = "Maximum length for the Description is 250 characters.")]
		public string Description { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}