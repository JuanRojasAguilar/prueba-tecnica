using System;

namespace api.Application.Exceptions;

public class NotEnoughStockException : Exception
{
    public NotEnoughStockException() : base("There is no enough product in stock")
    {

    }
}
