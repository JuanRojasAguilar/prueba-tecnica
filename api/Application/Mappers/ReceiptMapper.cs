using System;
using api.Dtos.Receipt;
using api.Models;

namespace api.Mappers;

public static class ReceiptMapper
{
    public static ReceiptDto ToDtoFromModel(this Receipt receiptModel)
    {
        var receiptDetailsList = receiptModel.ReceiptDetails.Select(rd => rd.ToReceiptDetailsDto()).ToList();
        return new ReceiptDto
        {
            Id = receiptModel.Id,
            CreatedOn = receiptModel.CreatedOn,
            ReceiptDetails = receiptDetailsList,
            Customer = receiptModel.Customer,
            CustomerId = receiptModel.CustomerId,
        };
    }

    public static Receipt ToModelFromDto(this ReceiptDto receiptDto)
    {
        List<ReceiptDetails> details = receiptDto.ReceiptDetails
                                       .Select(d => d.ToModelFromDto())
                                       .ToList();
        return new Receipt
        {
            Id = receiptDto.Id,
            CreatedOn = receiptDto.CreatedOn,
            CustomerId = receiptDto.CustomerId,
            ReceiptDetails = details
        };
    }

    public static Receipt ToModelFromCreate(this CreateReceiptDto receiptDto)
    {
        return new Receipt
        {

            CustomerId = receiptDto.CustomerId,
            ReceiptDetails = receiptDto.productList.Select(product => product.ToModelFromCreateDto()).ToList(),
        };
    }
}
