using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class Order
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Order date is a required field.")]
		public DateTime OrderDate { get; set; }

		[Required(ErrorMessage = "Total amount is a required field.")]
		public decimal TotalAmount { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; }
		public User User { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
