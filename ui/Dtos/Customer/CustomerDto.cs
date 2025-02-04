using System;
using System.ComponentModel.DataAnnotations;

namespace ui.Dtos.Customer;

public class CustomerDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
