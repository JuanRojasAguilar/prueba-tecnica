using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Customer;

public class CustomerAuditDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public DateTime CreatedOn { get; set; }
}
