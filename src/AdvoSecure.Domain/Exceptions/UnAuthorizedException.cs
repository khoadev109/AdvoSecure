using System;

namespace AdvoSecure.Domain.Exceptions;

public class UnAuthorizedException : Exception
{
    public UnAuthorizedException(string? message) : base(message)
    {
    }
}
