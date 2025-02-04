using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Keyless]
[Table("CustomerAudit")]
public class CustomerAudit
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
