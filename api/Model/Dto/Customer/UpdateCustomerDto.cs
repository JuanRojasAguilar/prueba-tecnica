using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Customer;

public class UpdateCustomerDto
{
    [Required]
    [MinLength(1, ErrorMessage = "Customer name cannot be empty")]
    [MaxLength(255, ErrorMessage = "Customer name too long, cannot exceed 255 characters")]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "Phone number cannot be empty")]
    public string Phone { get; set; }
}
