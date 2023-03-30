using System;

namespace AdvoSecure.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }
}
