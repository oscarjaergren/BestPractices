using BenchmarkDotNet.Attributes;
using Jargar.Playgrounds.Loggers.Benchmarks.SeriLogger;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Jargar.Playgrounds.Loggers.Benchmarks.ZLogger;

[MemoryDiagnoser]
public class ZLoggerBenchmark
{
    private readonly ILogger _zLogger;

    public ZLoggerBenchmark()
    {
        // Create ZLogger
        ILoggerFactory zLoggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());
        _zLogger = new Logger<SeriLogBenchmark>(zLoggerFactory);
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