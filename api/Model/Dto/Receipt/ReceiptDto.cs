using System;
using api.Dtos;
using api.Model.DbModel;
using api.Model.DbModel.Administration;
using api.Model.Dto.ReceiptDetails;

namespace api.Model.Dto.Receipt;

public class ReceiptDto
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public List<ReceiptDetailDto> ReceiptDetails { get; set; } = new List<ReceiptDetailDto>();
}
