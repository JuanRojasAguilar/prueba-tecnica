using System;
using System.ComponentModel.DataAnnotations;

namespace ui.Dtos.Customer;

public class CreateCustomerDto
{
    [Required(ErrorMessage = "Ingresa la identificación del cliente")]
    public string Id { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Ingresa el nombre del cliente")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa el correo del cliente")]
    [EmailAddress(ErrorMessage = "Ingresa un correo válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Ingresa el teléfono del cliente")]
    public string Phone { get; set; }
}
