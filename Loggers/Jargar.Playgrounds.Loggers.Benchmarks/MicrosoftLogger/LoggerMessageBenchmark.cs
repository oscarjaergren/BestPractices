using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jargar.Playgrounds.Loggers.Benchmarks.MicrosoftLogger;
internal class LoggerMessageBenchmark
{
    private static readonly Action<ILogger, string, Exception?> _logHelloWorld =
    LoggerMessage.Define<string>(
        logLevel: LogLevel.Information,
        eventId: 0,
        formatString: "Writing hello world response to {Name}");

    [Benchmark]
    public void LogZLogger()
    {
        _zLogger.ZLogInformation("Test");
    }
}
