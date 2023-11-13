using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Logging.SeriLogger;
internal class SeriLogBenchmark
{
    private readonly ILogger _seriHostLogger;

    private readonly Serilog.ILogger _seriLogger;

    public SeriLogBenchmark()
	{
        // Create SeriLogger
        ILoggerFactory seriLoggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
        _seriHostLogger = new Logger<LoggerBenchmark>(seriLoggerFactory);

        _seriLogger = SeriLogHelper.InitializeSerilog();
    }

    [Benchmark]
    public void SeriHostLogger()
    {
        _seriHostLogger.LogInformation("Test {Number}", 1);
    }

    [Benchmark]
    public void SeriLogLogger()
    {
        _seriLogger.Information("Test");
    }

    [Benchmark]
    public void SeriLogLogger_With_Param()
    {
        _seriLogger.Debug("Test {Number}", 1);
    }
}
