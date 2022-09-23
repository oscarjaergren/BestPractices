using BenchmarkDotNet.Attributes;
using Logging.NLog;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Logging;

[MemoryDiagnoser]
public class LoggerBenchmark
{
    private readonly ILogger _microsoftLogger;

    private readonly ILogger _nLogger;
    private readonly ILogger _seriLogger;

    private readonly ILogger _zLogger;


    // private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

    public LoggerBenchmark()
    {
        // Create SeriLogger
        var seriLoggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
        _seriLogger = new Logger<LoggerBenchmark>(seriLoggerFactory);

        // Create ZLogger
        var zloggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());
        _zLogger = new Logger<LoggerBenchmark>(zloggerFactory);

        // Create nLogger
        var nLoggerFactory = LoggerFactory.Create(builder => builder.AddNLog());
        _nLogger = new Logger<LoggerBenchmark>(nLoggerFactory);

        var microsoftLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _microsoftLogger = new Logger<LoggerBenchmark>(microsoftLoggerFactory);

        StaticLogger.Configure("Benchmark");
    }

    [Benchmark]
    public void SeriLogLogger()
    {
        _seriLogger.LogInformation("Test");
    }

    [Benchmark]
    public void LogZLogger()
    {
        _zLogger.ZLogDebug("Test");
    }

    [Benchmark]
    public void LogNlog()
    {
        _nLogger.LogDebug("Test");
    }

    [Benchmark]
    public void MicrosoftLogger()
    {
        _microsoftLogger.LogDebug("Test");
    }

    //[Benchmark]
    //public void StaticNlogger()
    //{
    //    StaticLogger.CurrentLogger.Debug("Test");
    //}
}