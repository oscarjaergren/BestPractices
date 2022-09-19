using System.Reflection;

namespace Logging.Logs;

public static class MethodTimeLogger
{
    public static void Log(MethodBase methodBase, long milliseconds, string message)
    {
        Logging.CurrentLogger.Info("Method {MethodName} took {Time} + {message}",
            methodBase.Name,
            milliseconds,
            message);
    }
}