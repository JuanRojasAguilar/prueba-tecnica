using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("Customer")]
[Index(nameof(DeletedOn))]
[Index(nameof(Name))]
public class Customer
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }

    public DateTime? DeletedOn { get; set; }
    public List<Receipt> Receipts { get; set; } = new List<Receipt>();
}
