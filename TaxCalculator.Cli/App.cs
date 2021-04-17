using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using TaxCalculator.Core.Application;
using TaxCalculator.Core.Services;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Cli
{
    /// <summary>
    /// The main application class.
    /// </summary>
    public class App : IApp
    {
        private readonly ISalaryService _salaryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        /// <inheritdoc />
        public async Task Run(string[] args)
        {
            CommandLineApplication cmdApp = new CommandLineApplication(throwOnUnexpectedArg: false);

            CommandOption grossAmount = cmdApp.Option("-g | --gross <amount>", "The amount of the gross salary.", CommandOptionType.SingleValue);
            CommandOption currency = cmdApp.Option(
                "-c | --currency <currencyCode>",
                "The currency of the salary. If not provided, the default value is IDR.",
                CommandOptionType.SingleValue);
            cmdApp.HelpOption("-? | -h | --help");

            cmdApp.OnExecute(() =>
            {
                if (grossAmount.HasValue())
                {
                    Salary grossSalary = _salaryService.BuildSalary(grossAmount.Value(), currency.Value());
                    Salary netSalary = _salaryService.GetNetSalary(grossSalary);

                    Console.WriteLine($"Net salary: {netSalary.Amount} {netSalary.Currency}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\nPress Ctrl+C to exit.\n");

                Console.ResetColor();

                return 0;
            });

            cmdApp.Execute(args);
            await Task.CompletedTask;
        }
    }
}
