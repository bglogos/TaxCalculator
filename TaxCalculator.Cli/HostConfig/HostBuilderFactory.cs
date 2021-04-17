using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxCalculator.Business.Services;
using TaxCalculator.Core.Application;
using TaxCalculator.Core.Services;

namespace TaxCalculator.Cli.HostConfig
{
    /// <summary>
    /// Factory methods for creating host builder objects.
    /// </summary>
    public static class HostBuilderFactory
    {
        /// <summary>
        /// Creates new <see cref="IHostBuilder"/>.
        /// </summary>
        /// <returns>A new <see cref="IHostBuilder"/> instance.</returns>
        public static IHostBuilder Create() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IApp, App>()
                        .AddTransient<ISalaryService, SalaryService>())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddFile("TaxCalculator.log", append: true);
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseConsoleLifetime();
    }
}
