using System;
using api.Dtos;
using api.Dtos.ReceiptDetails;
using api.Models;

namespace api.Mappers;

public static class ReceiptDetailsMapper
{
    public static ReceiptDetailDto ToReceiptDetailsDto(this ReceiptDetails receiptDetailsModel)
    {
        return new ReceiptDetailDto
        {
            Id = receiptDetailsModel.Id,
            ProductName = receiptDetailsModel.ProductName,
            Quantity = receiptDetailsModel.Quantity,
            UnitPrice = receiptDetailsModel.UnitPrice,
            ReceiptId = receiptDetailsModel.ReceiptId,
            ProductId = receiptDetailsModel.ProductId
        };
    }

    public static ReceiptDetails ToModelFromDto(this ReceiptDetailDto detailDto)
    {
        return new Models.ReceiptDetails
        {
            Id = detailDto.Id,
            ProductName = detailDto.ProductName,
            ProductId = detailDto.ProductId,
            Quantity = detailDto.Quantity,
            UnitPrice = detailDto.UnitPrice,
            ReceiptId = detailDto.ReceiptId,
        };
    }

    public static ReceiptDetails ToModelFromCreateDto(this CreateReceiptDetailDto receiptDetailsDto)
    {
        return new ReceiptDetails
        {
            Quantity = receiptDetailsDto.Quantity,
            ProductId = receiptDetailsDto.ProductId,
        };
    }
}
