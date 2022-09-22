using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Logging;

[MemoryDiagnoser]
public sealed class LoggerBenchmark
{
    private readonly ILogger _logger;
    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());

    public LoggerBenchmark()
    {
        _logger = new Logger<LoggerBenchmark>(_loggerFactory);
    }

    [Benchmark]
    public void LogZLogger()
    {
        _logger.ZLogDebug("Test");
    }

    [Benchmark]
    public void InBuiltHostLogger()
    {
        _logger.LogDebug("Test");
    }
}