using Microsoft.Extensions.Logging;

namespace TaxCalculator.Cli
{
    /// <summary>
    /// The main application class.
    /// </summary>
    public class App
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App(ILogger<App> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Runs the application with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Run(string[] args)
        {
            _logger.LogTrace($"Application starting with arguments {string.Join(", ", args)}");
        }
    }
}
