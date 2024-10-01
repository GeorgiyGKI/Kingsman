using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record OrderForManipulationDto
{
    [Required(ErrorMessage = "Order date is a required field.")]
    public DateTime OrderDate { get; init; }

    [Required(ErrorMessage = "Total amount is a required field.")]
    public decimal TotalAmount { get; init; }

    [Required]
    public Guid CustomerId { get; init; }
}
