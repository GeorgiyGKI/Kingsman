using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class OrderItem
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Quantity is a required field.")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Unit price is a required field.")]
		public decimal UnitPrice { get; set; }

		[ForeignKey(nameof(Order))]
		public Guid OrderId { get; set; }
		public Order Order { get; set; }

		[ForeignKey(nameof(Product))]
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
