using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace Logging.MicrosoftLogger;
internal class MicrosoftLoggerBenchmark
{
    private readonly ILogger _microsoftLogger;

    public MicrosoftLoggerBenchmark()
    {
        // Create Microsoft logger
        ILoggerFactory microsoftLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _microsoftLogger = new Logger<LoggerBenchmark>(microsoftLoggerFactory);
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
