using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Keyless]
[Table("ProductAudit")]
public class ProductAudit
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
