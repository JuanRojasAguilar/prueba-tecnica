using System;
using ui.Dtos.Customer;

namespace ui.Dtos.Receipt;

public class ReceiptDto
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string? CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }
    public List<ReceiptDetailDto> ReceiptDetails { get; set; } = new List<ReceiptDetailDto>();
}
