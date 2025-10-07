using System;
using System.ComponentModel.DataAnnotations.Schema;
using api.Model.DbModel.Administration;
using Microsoft.EntityFrameworkCore;

namespace api.Model.DbModel.Store.Receipt;

[Keyless]
[Table("ReceiptAudit")]
public class ReceiptAudit
{
    public int Id { get; set; }

    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
