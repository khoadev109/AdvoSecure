using System.Runtime.Serialization;

namespace AdvoSecure.Infrastructure.Security
{
    [Serializable]
    public class UnauthorizedTenantException : Exception
    {
        public UnauthorizedTenantException()
        {
        }

        public UnauthorizedTenantException(string? message) : base(message)
        {
        }

        public UnauthorizedTenantException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedTenantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}