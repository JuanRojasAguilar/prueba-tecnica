using api.Dtos.Product;
using api.Helpers;

namespace api.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync(ProductQuery query);
    Task<List<ProductAuditDto>> GetAllAuditsAsync(ProductQuery query);
    Task<ProductDto?> GetByIdAsync(string id);
    Task<ProductDto> CreateAsync(CreateProductDto productRequest);
    Task<ProductDto?> UpdateAsync(string id, UpdateProductDto productRequest);
    Task<ProductDto?> DeleteAsync(string id);
}
