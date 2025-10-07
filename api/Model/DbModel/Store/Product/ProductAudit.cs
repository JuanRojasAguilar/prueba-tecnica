using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Keyless]
[Table("ProductAudit")]
public class ProductAudit
{
    public long Id { get; init; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public long Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
