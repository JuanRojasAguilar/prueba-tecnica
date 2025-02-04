using System.ComponentModel.DataAnnotations;
using ui.Dtos.ReceiptDetails;

public class CreateReceiptDto
{
    [Required(ErrorMessage="Selecciona a un cliente")]
    public string CustomerId { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "The product list must contain at least one item.")]
    public List<CreateReceiptDetailDto> productList { get; set; }
}