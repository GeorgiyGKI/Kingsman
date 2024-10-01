using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class Category
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Category name is a required field.")]
		[MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
		public string Name { get; set; }

		public ICollection<Product> Products { get; set; }
	}

}
