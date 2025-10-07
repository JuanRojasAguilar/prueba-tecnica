using System;

namespace api.Application.Exceptions;

public class ReceiptDetailsNotFoundException : Exception
{
    public ReceiptDetailsNotFoundException() : base("Product recipe details not found")
    {

    }
}
