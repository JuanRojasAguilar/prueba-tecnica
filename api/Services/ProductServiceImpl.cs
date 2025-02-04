using api.Dtos.Product;
using api.Helpers;
using api.Interfaces;
using api.Mappers;

namespace api.Services;

public class ProductServiceImpl : ProductService
{
    private readonly ProductRepository _productRepo;
    public ProductServiceImpl(ProductRepository productRepository)
    {
        _productRepo = productRepository;
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto productRequest)
    {
        var product = await _productRepo.CreateAsync(productRequest);
        return product.ToProductDto();
    }

    public async Task<ProductDto?> DeleteAsync(string id)
    {
        var product = await _productRepo.DeleteAsync(id);
        return product!.ToProductDto();
    }

    public async Task<List<ProductDto>> GetAllAsync(ProductQuery query)
    {
        var products = await _productRepo.GetAllAsync(query);
        return products.Select(p => p.ToProductDto()).ToList();
    }

    public async Task<List<ProductAuditDto>> GetAllAuditoriesAsync(ProductQuery query)
    {
        var customersAuditories = await _productRepo.GetAllAuditoriesAsync(query);
        return customersAuditories.Select(c => c.ToDto()).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(string id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        return product!.ToProductDto();
    }

    public async Task<ProductDto?> UpdateAsync(string id, UpdateProductDto productRequest)
    {
        var product = await _productRepo.UpdateAsync(id, productRequest);
        return product!.ToProductDto();
    }
}