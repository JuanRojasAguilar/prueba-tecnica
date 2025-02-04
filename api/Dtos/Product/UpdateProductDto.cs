using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Product;

public class UpdateProductDto
{
    [Required]
    [MinLength(1, ErrorMessage = "Product name must be at least 1 character long")]
    [MaxLength(255, ErrorMessage = "Product name cannot exceed 255 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 1000000000000)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, 1000000000)]
    public int Stock { get; set; }
}
