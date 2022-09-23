using System.Reflection;
using Logging.SeriLogger;
using Logging.ZLogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ZLogger;

namespace BestPracticesConsoleApp;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var seriLogLogger = SeriLogHelper.InitializeSerilog();
        var contentRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        await Host.CreateDefaultBuilder(args)
            .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddHostedService<ConsoleHostedService>();
            })
            .UseSerilog(seriLogLogger)
            .RunConsoleAsync();

      
    }

    public static IHost BuildHost(string[] args) =>
        new HostBuilder()
            .UseSerilog() // <- Add this line
            .Build();
}