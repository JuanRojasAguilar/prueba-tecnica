using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Customer;

public class CreateCustomerDto
{
    public string Id { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }
}
