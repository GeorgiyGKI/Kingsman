using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models
{
	public class Product
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Product name is a required field.")]
		[MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
		public string Name { get; set; }


		[Required(ErrorMessage = "Description is a required field.")]
		[MaxLength(500, ErrorMessage = "Maximum length for the Description is 500 characters.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Price is a required field.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Stock quantity is a required field.")]
		public int Stock { get; set; }

		[Required(ErrorMessage = "Size is a required field.")]
		public Size Size { get; set; }

		[Required(ErrorMessage = "RefNumber is a required field.")]
		public string RefNumber { get; set; }

		/// <summary>
		/// ForeignFileds
		/// </summary>
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		[ForeignKey(nameof(Brand))]
		public int BrandId { get; set; }
		public Brand Brand { get; set; }

		[ForeignKey(nameof(Color))]
		public int ColorId { get; set; }
		public Color Color { get; set; }

	}
}
