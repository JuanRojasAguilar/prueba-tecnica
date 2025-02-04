using System;
using api.Dtos.Customer;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface CustomerRepository
{
    Task<List<Customer>> GetAllAsync(CustomerQuery query);
    Task<Customer?> GetByIdAsync(string id);
    Task<Customer> CreateAsync(CreateCustomerDto customerDto);
    Task<Customer?> UpdateAsync(string id, UpdateCustomerDto customerDto);
    Task<Customer?> DeleteAsync(string id);
    Task<List<CustomerAudit>> GetAllAuditoriesAsync(CustomerQuery query);
}
