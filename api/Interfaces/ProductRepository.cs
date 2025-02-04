using api.Dtos.Product;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface ProductRepository
{
    Task<List<Product>> GetAllAsync(ProductQuery query);
    Task<List<ProductAudit>> GetAllAuditoriesAsync(ProductQuery query);
    Task<Product?> GetByIdAsync(string id);
    Task<Product> CreateAsync(CreateProductDto productRequest);
    Task<Product?> UpdateAsync(string id, UpdateProductDto productRequest);
    Task<Product?> DeleteAsync(string id);
}
