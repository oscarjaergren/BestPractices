using BestPracticesConsoleApp;
using Logging.ZLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


internal sealed class Program
{
    private static async Task Main(string[] args)
    {

        await Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHostedService<ConsoleHostedService>();
               })
               .ConfigureLogging(logging => HostLogger.AddLogger(logging))
               .RunConsoleAsync();
    }
}




