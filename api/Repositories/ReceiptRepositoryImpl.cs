using System.Net;
using api.Data;
using api.Dtos;
using api.Dtos.Receipt;
using api.Exceptions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class ReceiptRepositoryImpl : ReceiptRepository
{
    private readonly ApplicationDBContext _context;

    public ReceiptRepositoryImpl(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Receipt>> GetAllAsync()
    {
        return await _context.Receipt.AsNoTracking().ToListAsync();
    }
    public async Task<Receipt?> GetByIdAsync(int id)
    {
        var receipt = await _context.Receipt
            .Include(r => r.Customer)
            .Include(r => r.ReceiptDetails)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (receipt == null) throw new ReceiptNotFoundException();

        return receipt;
    }
    public async Task<Receipt> CreateAsync(CreateReceiptDto receiptDto)
    {
        var receipt = receiptDto.ToModelFromCreate();

        var productIds = receipt.ReceiptDetails
                                .Select(rd => rd.ProductId)
                                .Distinct()
                                .ToHashSet();

        var products = await _context.Product
                                     .Where(p => productIds.Contains(p.Id))
                                     .ToDictionaryAsync(p => p.Id);

        foreach (var receiptDetail in receipt.ReceiptDetails)
        {
            if (products.TryGetValue(receiptDetail.ProductId, out var product))
            {
                receiptDetail.ProductName = product.Name;
                receiptDetail.UnitPrice = product.Price;
            }
            else
            {
                throw new Exception($"Product with Id {receiptDetail.ProductId} not found.");
            }
        }

        _context.Receipt.Add(receipt);
        await _context.SaveChangesAsync();

        return receipt;
    }
    public async Task<Receipt> CreateJ(CreateReceiptDto receiptDto)
    {
        var receipt = await _context.Receipt.AddAsync(receiptDto.ToModelFromCreate());
        var productList = new List<ReceiptDetailDto>();
        int receiptId = 0;

        receiptDto.productList.ForEach(async p =>
        {
            var product = await _context.Product.FirstOrDefaultAsync(pModel => pModel.Id == p.ProductId);

            if (product != null)
            {
                ++receiptId;

                productList.Add(new ReceiptDetailDto
                {
                    Id = receiptId,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = p.Quantity,
                    UnitPrice = product.Price,
                    ReceiptId = receipt.Entity.Id
                });

            }
        });

        ReceiptDto dto = new ReceiptDto
        {
            Id = receipt.Entity.Id,
            CustomerId = receiptDto.CustomerId,
            ReceiptDetails = productList
        };

        receipt = await _context.Receipt.AddAsync(dto.ToModelFromDto());
        await _context.SaveChangesAsync();

        return receipt.Entity;
    }

    public async Task<List<ReceiptOverview>> GetAllOverview()
    {
        return await _context.ReceiptOverview.AsNoTracking().ToListAsync();
    }
}
