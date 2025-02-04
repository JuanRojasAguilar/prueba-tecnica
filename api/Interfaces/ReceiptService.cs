using api.Dtos.Receipt;
using api.Models;

namespace api.Interfaces;

public interface ReceiptService
{
    Task<ReceiptDto> CreateAsync(CreateReceiptDto receiptDto);

    Task<List<ReceiptDto>> GetAllAsync();

    Task<List<ReceiptOverview>> GetAllOverview();

    Task<ReceiptDto?> GetByIdAsync(int id);
}
