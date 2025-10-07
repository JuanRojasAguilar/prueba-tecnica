using System;
using System.ComponentModel.DataAnnotations;

namespace api.Model.Dto.Product;

public class UpdateProductDto
{
    [Required]
    [MinLength(1, ErrorMessage = "Product name must be at least 1 character long")]
    [MaxLength(255, ErrorMessage = "Product name cannot exceed 255 characters")]
    public string Name { get; init; } = string.Empty;

    [Required]
    [Range(1, 1_000_000_000_000)]
    public decimal Price { get; init; }

    [Required]
    [Range(0, 1_000_000)]
    public int Stock { get; init; }
}
