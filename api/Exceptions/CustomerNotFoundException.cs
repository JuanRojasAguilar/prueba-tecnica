using System;

namespace api.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException() : base("Customer not found")
    {

    }
}
