using NLog;
using NLog.Config;

namespace Logging.NLog;

public static class Logging
{
    private static Logger? _currentLogger;

    public static Logger CurrentLogger
    {
        get => _currentLogger ?? throw new Exception("The logging needs to be configured before use");
        set => _currentLogger = value;
    }

    public static void Configure(string projectName, SessionRecord? sessionRecord = null)
    {
        LogManager.Configuration = LoggingConfigure.GetLoggingConfiguration(projectName, sessionRecord);
        CurrentLogger = LogManager.GetCurrentClassLogger();
    }
}