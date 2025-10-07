using System;

namespace api.Application.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException() : base("Product Not Found")
    {

    }
}
