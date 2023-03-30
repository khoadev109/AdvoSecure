using Serilog;

namespace AdvoSecure.Infrastructure.Helpers
{
    public class Logger
    {
        public static void LogInfo(string category, object value)
        {
            Log.Logger.Information($"{category} - {value}");
        }

        public static void LogWarning(string category, object value)
        {
            Log.Logger.Warning($"{category} - {value}");
        }

        public static void LogError(string category, Exception ex)
        {
            Log.Logger.Error($"{category} - {ex}");
        }

        public static void LogError(string category, string message)
        {
            Log.Logger.Error($"{category} - {message}");
        }

        public static void LogError(string category, string message, Exception ex)
        {
            Log.Logger.Error($"{category} - {message + ex}");
        }
    }
}
