using System;
using api.Data;
using api.Dtos.Customer;
using api.Exceptions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class CustomerProvider
{
    private readonly ApplicationDBContext _context;

    CustomerProvider(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Customer> CreateAsync(CreateCustomerDto customerDto)
    {
        var customer = customerDto.ToModelFromCreateDto();
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;

    }

    public async Task<Customer?> DeleteAsync(string id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null) throw new CustomerNotFoundException();

        customer.DeletedOn = new DateTime();

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<List<Customer>> GetAllAsync(CustomerQuery query)
    {
        var customers = _context.Customers
                        .Where(customer => customer.DeletedOn == null)
                        .AsNoTracking()
                        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            customers = customers.Where(c => c.Name.Contains(query.Name));
        }

        customers = query.IsDescending
                    ? customers.OrderByDescending(c => c.Name)
                    : customers.OrderBy(c => c.Name);

        int skip = (query.PageNumber - 1) * query.PageSize;

        return await customers
                     .Skip(skip)
                     .Take(query.PageSize)
                     .ToListAsync();
    }

    public async Task<List<CustomerAudit>> GetAllAuditoriesAsync(CustomerQuery query)
    {
        var customers = _context.CustomerAudit
                         .AsNoTracking()
                         .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            customers = customers.Where(c => c.Name.Contains(query.Name));
        }

        customers = query.IsDescending
                    ? customers.OrderByDescending(c => c.CreatedOn)
                    : customers.OrderBy(c => c.CreatedOn);

        int skip = (query.PageNumber - 1) * query.PageSize;

        return await customers
                     .Skip(skip)
                     .Take(query.PageSize)
                     .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(string id)
    {
        var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null || customer.DeletedOn != null)
        {
            throw new CustomerNotFoundException();
        }

        return customer;
    }

    public async Task<Customer?> UpdateAsync(string id, UpdateCustomerDto customerDto)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null || customer.DeletedOn != null) throw new CustomerNotFoundException();

        customer.Name = customerDto.Name;
        customer.Email = customerDto.Email;
        customer.Phone = customerDto.Phone;

        await _context.SaveChangesAsync();

        return customer;
    }

}
