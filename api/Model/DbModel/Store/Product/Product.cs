using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Model.DbModel.Store.Product;

[Table("Product")]
[Index(nameof(DeletedOn))]
[Index(nameof(Name))]
public class Product
{
    public string Id { get; init; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "BIGINT")]
    public long PriceInCents { get; set; }
    public int StockId { get; set; }
    public DateTime? DeletedOn { get; set; }
}
