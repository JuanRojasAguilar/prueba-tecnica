using System;

namespace api.Model.Queries;

public class ProductQuery
{
    public string? Name { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}
