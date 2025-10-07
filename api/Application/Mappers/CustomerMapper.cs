using System;
using api.Dtos.Customer;
using api.Models;

namespace api.Mappers;

public static class CustomerMapper
{
    public static CustomerDto ToDtoFromModel(this Customer customerModel)
    {
        return new CustomerDto
        {
            Id = customerModel.Id,
            Name = customerModel.Name,
            Email = customerModel.Email,
            Phone = customerModel.Phone
        };
    }

    public static Customer ToModelFromDto(this CustomerDto customerDto)
    {
        return new Customer
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
            Phone = customerDto.Phone
        };
    }
    public static Customer ToModelFromCreateDto(this CreateCustomerDto customerDto)
    {
        return new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Email = customerDto.Email,
            Phone = customerDto.Phone
        };
    }
}
