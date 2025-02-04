using System;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product productModel)
    {
        return new ProductDto
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Price = productModel.Price,
            Stock = productModel.Stock
        };
    }

    public static Product ToProductFromCreate(this CreateProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock
        };
    }

    public static Product ToProductFromUpdate(this UpdateProductDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock
        };
    }

    public static UpdateProductDto ToUpdateFromProduct(this Product productModel)
    {
        return new UpdateProductDto
        {
            Name = productModel.Name,
            Price = productModel.Price,
            Stock = productModel.Stock
        };
    }
}
