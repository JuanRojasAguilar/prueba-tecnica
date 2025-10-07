using api.Dtos.Product;
using api.Model.DbModel.Store.Product;
using api.Model.Dto.Product;
using api.Model.Queries;
using api.Models;
using api.Repository.Queries;

namespace api.Repository.Providers.Interfaces;

public interface IProductProvider
{
    Task<Product> CreateAsync(CreateProductDto productRequest);
    Task<Product?> DeleteAsync(string id);
    Task<Product?> GetAsync(string id);
    Task<List<Product>> GetAllAsync();
    Task<List<ProductAudit>> GetAllAuditsAsync(ProductQuery query);

    Task<Product> UpdateAsync(UpdateProductDto productRequest);
    
}