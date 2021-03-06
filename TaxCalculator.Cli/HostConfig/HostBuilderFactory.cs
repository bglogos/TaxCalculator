using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxCalculator.Business.Calculators;
using TaxCalculator.Business.Services;
using TaxCalculator.Core.Application;
using TaxCalculator.Core.Calculators;
using TaxCalculator.Core.Services;
using TaxCalculator.Models.Config;

namespace TaxCalculator.Cli.HostConfig
{
    /// <summary>
    /// Factory methods for creating host builder objects.
    /// </summary>
    public static class HostBuilderFactory
    {
        private static IConfigurationRoot _configurationRoot;

        /// <summary>
        /// Creates new <see cref="IHostBuilder"/>.
        /// </summary>
        /// <returns>A new <see cref="IHostBuilder"/> instance.</returns>
        public static IHostBuilder Create(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    _configurationRoot = configuration.Build();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddFile("TaxCalculator.log", append: true);
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IApp, App>()
                        .AddTransient<ISalaryService, SalaryService>()
                        .AddTransient<ITaxCalculatorFactory, TaxCalculatorFactory>()
                        .AddSingleton((_) =>
                        {
                            AppConfig appConfig = new();
                            _configurationRoot.GetSection(nameof(AppConfig)).Bind(appConfig);
                            return appConfig;
                        })
                        .AddHostedService<ConsoleHostedService>())
                .UseConsoleLifetime();
    }
}
