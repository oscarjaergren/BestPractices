using Serilog;

namespace Logging.SeriLogger;

public sealed class SeriLogHelper
{
    public static ILogger InitializeSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Async(writeTo => writeTo.Console())
            .CreateLogger();

        // self logging setting
        //SelfLog.Enable(msg => File.AppendAllText("logs\\serilog_internallog.log", msg, Encoding.UTF8));

        return Log.Logger;
    }
}