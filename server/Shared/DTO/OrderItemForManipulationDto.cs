using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record OrderItemForManipulationDto
{
    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; init; }

    [Required(ErrorMessage = "Unit price is a required field.")]
    public decimal UnitPrice { get; }

    [Required]
    public Guid ProductId { get; init; }
}
