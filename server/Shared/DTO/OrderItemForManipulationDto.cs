using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public record OrderItemForManipulationDto
{
    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; init; }

    [Required(ErrorMessage = "Unit price is a required field.")]
    public decimal UnitPrice { get; init; }

    [Required]
    public Guid OrderId { get; init; }

    [Required]
    public Guid ProductId { get; init; }
}
