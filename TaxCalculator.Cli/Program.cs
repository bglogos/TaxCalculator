using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxCalculator.Cli.HostConfig;
using TaxCalculator.Core.Application;

namespace TaxCalculator.Cli
{
    /// <summary>
    /// Main application entry point class.
    /// </summary>
    public static class Program
    {
        private static ILogger _logger;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            using IHost host = HostBuilderFactory.Create().Build();

            ILoggerFactory loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger(nameof(Program));

            IApp app = host.Services.GetRequiredService<IApp>();
            await app.Run(args);
            await host.RunAsync();
        }

        /// <summary>
        /// Default unhandled exception handler.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="args">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = args.ExceptionObject as Exception;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n {ex.Message} ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPress any key to exit.");
            Console.ResetColor();

            _logger.LogError(ex, ex.Message, args);

            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
