using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TaxCalculator.Cli.HostConfig;

namespace TaxCalculator.Cli
{
    /// <summary>
    /// Main application entry point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            await HostBuilderFactory.Create(args).RunConsoleAsync();
        }
    }
}
