﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                        .AddSingleton<App, App>())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Error);
                });
    }
}
