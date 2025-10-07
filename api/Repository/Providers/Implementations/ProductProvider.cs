using api.Application.Exceptions;
using api.Application.Mappers;
using api.Model.DbModel.Store.Product;
using api.Model.Dto.Product;
using api.Model.Queries;
using api.Model.Utils;
using api.Models;
using api.Repository.Data;
using api.Repository.Providers.Interfaces;
using api.Repository.Queries;
using Microsoft.EntityFrameworkCore;
using api.Repository.Providers.Interfaces;

namespace api.Repository.Providers.Implementations;

public class ProductProvider : IProductProvider
{
    private readonly ApplicationDBContext _context;
    private readonly PriceConverter _priceConverter = PriceConverter.Instance;
    ProductProvider(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(CreateProductDto productRequest)
    {
        var product = productRequest.ToProductFromCreate();
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> DeleteAsync(string id)
    {
        var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null || product.DeletedOn != null) throw new ProductNotFoundException();

        product.DeletedOn = new DateTime();

        _context.Product.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetByBrandAsync(string brand)
    {
        throw new NotImplementedException();
    }

    public Task GetByModelAsync(string model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateProductDto productRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductAudit>> GetAllAuditsAsync(ProductQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetAllAsync(ProductQuery query)
    {
        var products = _context.Product
                .Where(product => product.DeletedOn == null)
                .AsNoTracking()
                .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            products = products.Where(c => c.Name.Contains(query.Name));
        }

        products = query.IsDescending
                   ? products.OrderByDescending(p => p.Name)
                   : products.OrderBy(p => p.Name);

        int skip = (query.PageNumber - 1) * query.PageSize;

        return await products
                    .Skip(skip)
                    .Take(query.PageSize)
                    .ToListAsync();
    }

    public async Task<List<ProductAudit>> GetAllAuditsAsync(ProductQuery query)
    {
        var products = _context.ProductAudit
                  .AsNoTracking()
                  .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            products = products.Where(c => c.Name.Contains(query.Name));
        }

        products = query.IsDescending
                   ? products.OrderByDescending(p => p.CreatedOn)
                   : products.OrderBy(p => p.CreatedOn);

        int skip = (query.PageNumber - 1) * query.PageSize;

        return await products
                    .Skip(skip)
                    .Take(query.PageSize)
                    .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        var product = await _context.Product
                        .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null || product.DeletedOn != null) throw new ProductNotFoundException();

        return product;
    }

    public async Task<Product?> UpdateAsync(string id, UpdateProductDto productRequest)
    {
        var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null || product.DeletedOn != null) throw new ProductNotFoundException();

        long priceInCents = _priceConverter.ConvertToLong(productRequest.Price);
        
        product.Name = productRequest.Name;
        product.PriceInCents = priceInCents;
        product.StockId = productRequest.Stock;

        await _context.SaveChangesAsync();

        return product;
    }

    Task IProductProvider.DeleteAsync(string id)
    {
        return DeleteAsync(id);
    }
}
