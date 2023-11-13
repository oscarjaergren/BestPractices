using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Logging.ZLogger;

internal class ZLoggerBenchmark
{
    private readonly ILogger _zLogger;

    public ZLoggerBenchmark()
    {
        // Create ZLogger
        ILoggerFactory zLoggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());
        _zLogger = new Logger<LoggerBenchmark>(zLoggerFactory);
    }

    [Benchmark]
    public void LogZLogger()
    {
        _zLogger.ZLogInformation("Test");
    }

    [Benchmark]
    public void LogZLogger_With_Param()
    {
        _zLogger.ZLogInformationWithPayload(1, "Test {1}");
    }
}