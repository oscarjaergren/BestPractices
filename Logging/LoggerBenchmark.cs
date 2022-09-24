using BenchmarkDotNet.Attributes;
using Logging.SeriLogger;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using Serilog;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = NLog.LogLevel;

namespace Logging;

[MemoryDiagnoser]
public class LoggerBenchmark
{
    private static Logger StaticNLogger;
    private readonly ILogger _microsoftLogger;

    private readonly ILogger _nLogger;

    private readonly ILogger _seriHostLogger;

    private readonly Serilog.ILogger _seriLogger;


    private readonly ILogger _zLogger;

    public LoggerBenchmark()
    {
        // Create SeriLogger
        var seriLoggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
        _seriHostLogger = new Logger<LoggerBenchmark>(seriLoggerFactory);

        _seriLogger = SeriLogHelper.InitializeSerilog();

        // Create ZLogger
        var zLoggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());
        _zLogger = new Logger<LoggerBenchmark>(zLoggerFactory);

        // Create nLogger
        var nLoggerFactory = LoggerFactory.Create(builder => builder.AddNLog());
        _nLogger = new Logger<LoggerBenchmark>(nLoggerFactory);

        // Create Microsoft logger
        var microsoftLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _microsoftLogger = new Logger<LoggerBenchmark>(microsoftLoggerFactory);

        LoggingConfiguration config = new();
        DebugConfig(ref config);
        StaticNLogger = LogManager.GetCurrentClassLogger();
    }

    private static void DebugConfig(ref LoggingConfiguration config)
    {
        DebuggerTarget debugTarget = new();
        config.AddTarget("debug", debugTarget);
        LoggingRule rule1 = new("*", LogLevel.Debug, debugTarget);
        config.LoggingRules.Add(rule1);
    }

    [Benchmark]
    public void SeriHostLogger()
    {
        _seriHostLogger.LogDebug("Test {Number}", 1);
    }

    [Benchmark]
    public void SeriLogLogger()
    {
        _seriLogger.Debug("Test");
    }

    [Benchmark]
    public void SeriLogLogger_With_Param()
    {
        _seriLogger.Debug("Test {Number}", 1);
    }

    [Benchmark]
    public void LogZLogger()
    {
        _zLogger.ZLogDebug("Test");
    }

    [Benchmark]
    public void LogZLogger_With_Param()
    {
        _zLogger.ZLogDebugWithPayload(1, "Test {1}");
    }

    [Benchmark]
    public void LogNlog()
    {
        _nLogger.LogDebug("Test");
    }

    [Benchmark]
    public void StaticLogNlog_With_Param()
    {
        StaticNLogger.Debug("Test {Number}", 1);
    }

    [Benchmark]
    public void LogNlog_With_Param()
    {
        _nLogger.LogDebug("Test {Number}", 1);
    }

    [Benchmark]
    public void MicrosoftLogger()
    {
        _microsoftLogger.LogDebug("Test");
    }

    [Benchmark]
    public void MicrosoftLogger_With_Param()
    {
        _microsoftLogger.LogDebug("Test {Number}", 1);
    }
}