using System;
using System.ComponentModel.DataAnnotations;

namespace ui.Dtos.Product;

public class CreateProductDto
{
    [Required(ErrorMessage = "Ingresa un id")]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa el nombre del producto")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa el precio del producto")]
    [Range(1, 1000000000000, ErrorMessage="El precio debe ser mayor a 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Ingresa el stock del producto")]
    [Range(0, 1000000000, ErrorMessage="El stock debe ser mayor a 0")]
    public int Stock { get; set; }
}
