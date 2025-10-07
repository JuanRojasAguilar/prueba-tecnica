using System;
using api.Dtos.Customer;
using api.Models;

namespace api.Mappers;

public static class CustomerAuditMapper
{
    public static CustomerAuditDto ToDtoFromModel(this CustomerAudit customerModel)
    {
        return new CustomerAuditDto
        {
            Id = customerModel.Id,
            Name = customerModel.Name,
            Email = customerModel.Email,
            Phone = customerModel.Phone!,
            CreatedOn = customerModel.CreatedOn
        };
    }

    public static CustomerAudit ToModelFromDto(this CustomerAuditDto customerDto)
    {
        return new CustomerAudit
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
            Phone = customerDto.Phone,
            CreatedOn = customerDto.CreatedOn
        };
    }
}
