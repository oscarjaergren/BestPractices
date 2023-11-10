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

    static LoggerBenchmark()
    {
        StaticNLogger = LogManager.GetCurrentClassLogger();
    }

    /// <summary>
    ///     So what are testing here?
    ///     We are testing
    ///     Nlog
    ///     SeriLog
    ///     Microsoft "Inbuilt" Host Logger
    ///     ZLogger
    ///     and how these interact with hostlogger.
    ///     These Loggers should be used Programmatically (but other approaches may be explored)
    ///     We test the basic functions such as an empty log message and one with parameters.
    ///     What is important is to find whichever uses less memory, second concern is the speed.
    /// </summary>
    public LoggerBenchmark()
    {
        // Create SeriLogger
        ILoggerFactory seriLoggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
        _seriHostLogger = new Logger<LoggerBenchmark>(seriLoggerFactory);

        _seriLogger = SeriLogHelper.InitializeSerilog();

        // Create ZLogger
        ILoggerFactory zLoggerFactory = LoggerFactory.Create(builder => builder.AddZLoggerConsole());
        _zLogger = new Logger<LoggerBenchmark>(zLoggerFactory);

        // Create nLogger
        ILoggerFactory nLoggerFactory = LoggerFactory.Create(builder => builder.AddNLog());
        _nLogger = new Logger<LoggerBenchmark>(nLoggerFactory);

        // Create Microsoft logger
        ILoggerFactory microsoftLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _microsoftLogger = new Logger<LoggerBenchmark>(microsoftLoggerFactory);

        LoggingConfiguration config = new();
        DebugConfig(ref config);
        LogManager.Configuration = config;
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

    [Benchmark]
    public void HostNlogger()
    {
        _nLogger.LogInformation("Test");
    }

    //[Benchmark]
    //public static void StaticNlogger()
    //{
    //    StaticNLogger.Info("Test {Number}", 1);
    //}

    [Benchmark]
    public void HostNlogger_With_Param()
    {
        _nLogger.LogInformation("Test {Number}", 1);
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