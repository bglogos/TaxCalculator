using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxCalculator.Core.Application;

namespace TaxCalculator.Cli.HostConfig
{
    /// <summary>
    /// The default console hosted service.
    /// </summary>
    /// <seealso cref="IHostedService" />
    internal sealed class ConsoleHostedService : IHostedService
    {
        private readonly IApp _app;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHostedService" /> class.
        /// </summary>
        /// <param name="app">The main application.</param>
        /// <param name="appLifetime">The application lifetime.</param>
        /// <param name="logger">The event logger.</param>
        public ConsoleHostedService(
            IApp app,
            IHostApplicationLifetime appLifetime,
            ILogger<ConsoleHostedService> logger)
        {
            _app = app;
            _appLifetime = appLifetime;
            _logger = logger;
        }

        /// <inheritdoc />
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(async () =>
            {
                try
                {
                    string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();
                    await _app.RunAsync(args);
                }
                catch (Exception ex)
                {
                    UnhandledExceptionHandler(ex);
                }
                finally
                {
                    _appLifetime.StopApplication();
                }
            });

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Default unhandled exception handler.
        /// </summary>
        /// <param name="ex">The exception.</param>
        private void UnhandledExceptionHandler(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n {ex.Message} ");
            Console.ResetColor();

            _logger.LogError(ex, ex.Message);
        }
    }
}
