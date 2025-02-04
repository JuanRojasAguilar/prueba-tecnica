using System;

namespace api.Exceptions;

public class ReceiptDetailsNotFoundException : Exception
{
    public ReceiptDetailsNotFoundException() : base("Product recipe details not found")
    {

    }
}
