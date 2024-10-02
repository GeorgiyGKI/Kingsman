using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record OrderForManipulationDto
{
    [Required(ErrorMessage = "Order date is a required field.")]
    public DateTime OrderDate { get; init; }

    [Required(ErrorMessage = "Total amount is a required field.")]
    public decimal TotalAmount { get; init; }

    [Required]
    public string UserId { get; init; }
    [Required(ErrorMessage = "Order must contains OrdeItems")]
    public ICollection<OrderItemForManipulationDto> OrderItems { get; init; }
}
