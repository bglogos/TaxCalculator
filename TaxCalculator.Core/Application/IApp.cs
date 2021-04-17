using System.Threading.Tasks;

namespace TaxCalculator.Core.Application
{
    /// <summary>
    /// The main application interface.
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// Runs the application with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        Task Run(string[] args);
    }
}
