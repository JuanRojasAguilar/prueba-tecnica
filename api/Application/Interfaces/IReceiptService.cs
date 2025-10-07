using api.Dtos.Receipt;
using api.Models;

namespace api.Application.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> CreateAsync(CreateReceiptDto receiptDto);

    Task<List<ReceiptDto>> GetAllAsync();

    Task<List<ReceiptOverview>> GetAllOverview();

    Task<ReceiptDto?> GetByIdAsync(int id);
}
