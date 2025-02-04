using System;
using System.ComponentModel.DataAnnotations;

namespace ui.Dtos.Account;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string? Email;

    [Required]
    public string? Password;

}
