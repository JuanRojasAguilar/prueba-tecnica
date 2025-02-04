using api.Models;

namespace api.Interfaces;

public interface ReceiptRepository
{
    Task<List<Receipt>> GetAllAsync();

    Task<List<ReceiptOverview>> GetAllOverview();
    Task<Receipt?> GetByIdAsync(int id);
    Task<Receipt> CreateAsync(CreateReceiptDto receiptDto);
}
