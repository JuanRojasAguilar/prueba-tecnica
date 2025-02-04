using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("Receipt")]
public class Receipt
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<ReceiptDetails> ReceiptDetails { get; set; } = new List<ReceiptDetails>();
}
