using System;

namespace api.Exceptions;

public class NotEnoughStockException : Exception
{
    public NotEnoughStockException() : base("There is no enough product in stock")
    {

    }
}
