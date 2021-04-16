using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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
        public static Task Main(string[] args)
        {
            using IHost host = HostBuilderFactory.Create().Build();
            App app = host.Services.GetService<App>();
            app.Run(args);
            return host.RunAsync();
        }
    }
}
