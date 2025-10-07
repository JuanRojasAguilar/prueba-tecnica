using api.Dtos.Customer;
using api.Model.Queries;


namespace api.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync(CustomerQuery query);
    Task<CustomerDto?> GetByIdAsync(string id);
    Task<CustomerDto> CreateAsync(CreateCustomerDto customerDto);
    Task<CustomerDto?> UpdateAsync(string id, UpdateCustomerDto customerDto);
    Task<CustomerDto?> DeleteAsync(string id);
    Task<List<CustomerAuditDto>> GetAllAuditsAsync(CustomerQuery query);
}
