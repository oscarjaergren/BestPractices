using NLog;
using NLog.Config;

namespace Logging.Logs;

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
        LoggingConfiguration logConfig = LoggingConfigure.GetLoggingConfiguration(projectName, sessionRecord);

        LogManager.Configuration = logConfig;
        Logger? logger = LogManager.GetCurrentClassLogger();
        CurrentLogger = logger;
    }
}
