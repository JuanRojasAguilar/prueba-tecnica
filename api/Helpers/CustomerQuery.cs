using System;

namespace api.Helpers;

public class CustomerQuery
{
    public string? Name { get; set; } = null;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public bool IsDescending { get; set; } = false;
}
