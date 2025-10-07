using System;

namespace api.Application.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException() : base("Customer not found")
    {

    }
}
