using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.ReceiptDetails;

public class CreateReceiptDetailDto
{
    [Required]
    public string ProductId { get; set; }

    [Required]
    [Range(1, 1000000000)]
    public int Quantity { get; set; }
}
