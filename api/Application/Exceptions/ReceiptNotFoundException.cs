using System;

namespace api.Application.Exceptions;

public class ReceiptNotFoundException : Exception
{
    public ReceiptNotFoundException() : base("Receipt not found")
    {

    }
}
