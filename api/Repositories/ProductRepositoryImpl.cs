using api.Data;
using api.Dtos.Product;
using api.Exceptions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class ProductRepositoryImpl : ProductRepository
{
    private readonly ApplicationDBContext _context;
    public ProductRepositoryImpl(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(CreateProductDto productRequest)
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

    public async Task<List<ProductAudit>> GetAllAuditoriesAsync(ProductQuery query)
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

        product.Name = productRequest.Name;
        product.Price = productRequest.Price;
        product.Stock = productRequest.Stock;

        await _context.SaveChangesAsync();

        return product;
    }
}
