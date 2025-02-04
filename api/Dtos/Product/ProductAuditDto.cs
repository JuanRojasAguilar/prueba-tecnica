using System;

namespace api.Dtos.Product;

public class ProductAuditDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedOn { get; set; }
}
