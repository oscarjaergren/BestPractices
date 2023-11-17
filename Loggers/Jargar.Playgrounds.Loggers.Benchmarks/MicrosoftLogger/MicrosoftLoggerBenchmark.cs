using BenchmarkDotNet.Attributes;
using Jargar.Playgrounds.Loggers.Benchmarks.SeriLogger;
using Microsoft.Extensions.Logging;

namespace Jargar.Playgrounds.Loggers.Benchmarks.MicrosoftLogger;

public class MicrosoftLoggerBenchmark
{
    private readonly ILogger _microsoftLogger;

    public MicrosoftLoggerBenchmark()
    {
        // Create Microsoft logger
        ILoggerFactory microsoftLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _microsoftLogger = new Logger<SeriLogBenchmark>(microsoftLoggerFactory);
    }

    [Benchmark]
    public void MicrosoftLogger()
    {
        _microsoftLogger.LogInformation("Test");
    }

    [Benchmark]
    public void MicrosoftLogger_With_Param()
    {
        _microsoftLogger.LogInformation("Test {Number}", 1);
    }
}
