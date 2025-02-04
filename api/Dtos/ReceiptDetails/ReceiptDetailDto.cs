using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class ReceiptDetailDto
{
    public int Id { get; set; }

    public string ProductId { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    [Required]
    public int ReceiptId { get; set; }
}
