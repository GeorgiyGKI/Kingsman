using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Shared.DTO;

public record ProductForManipulationDto
{
    [Required(ErrorMessage = "Product name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(500, ErrorMessage = "Maximum length for the Description is 500 characters.")]
    public string Description { get; init; }

    [Required(ErrorMessage = "Price is a required field.")]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "Stock quantity is a required field.")]
    public int Stock { get; init; }

    [Required(ErrorMessage = "Size is a required field.")]
    public Size Size { get; init; }

    [Required(ErrorMessage = "RefNumber is a required field.")]
    public string RefNumber { get; init; }

    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    public Guid BrandId { get; init; }

    [Required]
    public int ColorId { get; init; }
}
