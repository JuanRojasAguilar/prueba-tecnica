using System.ComponentModel.DataAnnotations;
using api.Dtos.ReceiptDetails;

public class CreateReceiptDto
{
    [Required]
    public required string CustomerId { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "The product list must contain at least one item.")]
    public required List<CreateReceiptDetailDto> productList { get; set; }
}