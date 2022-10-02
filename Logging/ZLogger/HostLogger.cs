using Microsoft.Extensions.Logging;
using ZLogger;

namespace Logging.ZLogger;

/// <summary>
///     https://github.com/Cysharp/ZLogger
/// </summary>
public sealed class HostLogger
{
    public static ILoggingBuilder AddLogger(ref ILoggingBuilder logger)
    {
        // optional(MS.E.Logging):clear default providers.
        logger.ClearProviders();

        // optional(MS.E.Logging): default is Info, you can use this or AddFilter to filtering log.
        logger.SetMinimumLevel(LogLevel.Debug);

        // Add File Logging.
        logger.AddZLoggerFile("fileName.log");

        // Add Rolling File Logging.
        logger.AddZLoggerRollingFile((dt, x) => $"logs/{dt.ToLocalTime():yyyy-MM-dd}_{x:000}.log",
            x => x.ToLocalTime().Date, 1024);

        //  Add Console Logging and Enable Structured Logging
        logger.AddZLoggerConsole(options => options.EnableStructuredLogging = true);

        return logger;
    }
}