using System;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers;

public static class ProductAuditMapper
{
    public static ProductAuditDto ToDto(this ProductAudit productModel)
    {
        return new ProductAuditDto
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Price = productModel.Price,
            Stock = productModel.Stock,
            CreatedOn = productModel.CreatedOn
        };
    }
}
