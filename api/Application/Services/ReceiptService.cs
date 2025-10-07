using api.Dtos.Receipt;
using api.Exceptions;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Application.Services;

public class ReceiptService : IReceiptService
{
    private readonly ReceiptRepository _receiptRepo;

    public ReceiptService(ReceiptRepository receiptRepository)
    {
        _receiptRepo = receiptRepository;
    }


    public async Task<ReceiptDto> CreateAsync(CreateReceiptDto receiptDto)
    {
        Receipt dto = await _receiptRepo.CreateAsync(receiptDto);

        return dto.ToDtoFromModel();

    }

    public async Task<List<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _receiptRepo.GetAllAsync();
        return receipts.Select(r => r.ToDtoFromModel()).ToList();
    }

    public Task<List<ReceiptOverview>> GetAllOverview()
    {
        return _receiptRepo.GetAllOverview();
    }

    public async Task<ReceiptDto?> GetByIdAsync(int id)
    {
        var receipt = await _receiptRepo.GetByIdAsync(id);
        if (receipt == null)
        {
            throw new ReceiptNotFoundException();
        }
        return receipt.ToDtoFromModel();
    }
}