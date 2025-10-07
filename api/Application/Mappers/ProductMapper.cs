using System;
using api.Dtos.Product;
using api.Model.Utils;
using api.Models;

namespace api.Application.Mappers;

public static class ProductMapper
{
    private static PriceConverter _priceConverter = PriceConverter.Instance;
    public static ProductDto ToProductDto(this Product productModel)
    {
        return new ProductDto
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Price = productModel.PriceInCents,
            Stock = productModel.StockId
        };
    }

    public static Product ToProductFromCreate(this CreateProductDto productDto)
    {
        long priceInCents = _priceConverter.ConvertToLong(productDto.Price);
        
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            PriceInCents = priceInCents,
            StockId = productDto.Stock
        };
    }

    public static Product ToProductFromUpdate(this UpdateProductDto productDto)
    {
        long priceInCents = _priceConverter.ConvertToLong(productDto.Price);
        return new Product
        {
            Name = productDto.Name,
            PriceInCents = priceInCents,
            StockId = productDto.Stock
        };
    }

    public static UpdateProductDto ToUpdateFromProduct(this Product productModel)
    {
        return new UpdateProductDto
        {
            Name = productModel.Name,
            Price = productModel.PriceInCents,
            Stock = productModel.StockId
        };
    }
}
