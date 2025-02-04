using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("ReceiptDetails")]
public class ReceiptDetails
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    public int ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }

    public string ProductId { get; set; }
    public Product? Product { get; set; }
}
