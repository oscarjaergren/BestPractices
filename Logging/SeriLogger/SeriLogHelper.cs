using System.Text;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;

namespace Logging.SeriLogger;

internal sealed class SeriLogHelper
{
    private static ILogger InitializeSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(writeTo => writeTo.Console())
            .CreateLogger();

        // self logging setting
        //SelfLog.Enable(msg => File.AppendAllText("logs\\serilog_internallog.log", msg, Encoding.UTF8));

        return Log.Logger;
    }
}