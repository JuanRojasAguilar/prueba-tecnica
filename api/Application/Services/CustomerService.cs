using api.Dtos.Customer;
using api.Helpers;
using api.Interfaces;
using api.Mappers;

namespace api.Services;

public class CustomerService : Interfaces.ICustomerService
{
    private readonly CustomerRepository _customerRepo;
    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepo = customerRepository;
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto customerDto)
    {
        var customer = await _customerRepo.CreateAsync(customerDto);
        return customer.ToDtoFromModel();
    }

    public async Task<CustomerDto?> DeleteAsync(string id)
    {
        var customer = await _customerRepo.DeleteAsync(id);
        return customer.ToDtoFromModel();
    }

    public async Task<List<CustomerDto>> GetAllAsync(CustomerQuery query)
    {
        var customers = await _customerRepo.GetAllAsync(query);
        return customers.Select(c => c.ToDtoFromModel()).ToList();
    }

    public async Task<List<CustomerAuditDto>> GetAuditories(CustomerQuery query)
    {
        var customersAuditories = await _customerRepo.GetAllAuditoriesAsync(query);
        return customersAuditories.Select(c => c.ToDtoFromModel()).ToList();
    }

    public async Task<CustomerDto?> GetByIdAsync(string id)
    {
        var customer = await _customerRepo.GetByIdAsync(id);
        return customer.ToDtoFromModel();
    }

    public async Task<CustomerDto?> UpdateAsync(string id, UpdateCustomerDto customerDto)
    {
        var customer = await _customerRepo.UpdateAsync(id, customerDto);
        return customer.ToDtoFromModel();
    }
}