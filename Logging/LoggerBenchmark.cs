using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Logging;

[MemoryDiagnoser]
public class LoggerBenchmark
{
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
    public LoggerBenchmark(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(LoggerBenchmark).Assembly).Run(args);
    }
}