using api.Dtos.Customer;
using api.Helpers;

namespace api.Interfaces;

public interface CustomerService
{
    Task<List<CustomerDto>> GetAllAsync(CustomerQuery query);
    Task<CustomerDto?> GetByIdAsync(string id);
    Task<CustomerDto> CreateAsync(CreateCustomerDto customerDto);
    Task<CustomerDto?> UpdateAsync(string id, UpdateCustomerDto customerDto);
    Task<CustomerDto?> DeleteAsync(string id);
    Task<List<CustomerAuditDto>> GetAuditories(CustomerQuery query);
}
