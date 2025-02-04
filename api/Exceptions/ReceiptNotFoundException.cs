using System;

namespace api.Exceptions;

public class ReceiptNotFoundException : Exception
{
    public ReceiptNotFoundException() : base("Receipt not found")
    {

    }
}
