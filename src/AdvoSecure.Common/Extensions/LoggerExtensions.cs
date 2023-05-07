using Serilog;
using System.Runtime.CompilerServices;

namespace AdvoSecure.Infrastructure.Extensions
{
    public static class LoggerExtensions
    {        
        public static ILogger Here(this ILogger logger, object instance,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)            
        {
            return logger
                .ForContext("TypeName", instance.GetType().Name)
                .ForContext("MemberName", memberName)
                .ForContext("FilePath", sourceFilePath)
                .ForContext("LineNumber", sourceLineNumber);
        }
    }
}
