using System;
using System.ComponentModel.DataAnnotations;

namespace ui.Dtos.Customer;

public class UpdateCustomerDto
{
    [Required(ErrorMessage = "Ingresa el nombre del cliente")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Ingresa el correo del cliente")]
    [EmailAddress(ErrorMessage = "Ingresa un correo válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Ingresa el teléfono del cliente")]
    public string Phone { get; set; }
}
