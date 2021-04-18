using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using TaxCalculator.Core.Application;
using TaxCalculator.Core.Services;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Constants;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Cli
{
    /// <summary>
    /// The main application class.
    /// </summary>
    public class App : IApp
    {
        private readonly ISalaryService _salaryService;
        private readonly AppConfig _appConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="salaryService">The salary service.</param>
        /// <param name="appConfig">The application configuration.</param>
        public App(
            ISalaryService salaryService,
            AppConfig appConfig)
        {
            _salaryService = salaryService;
            _appConfig = appConfig;
        }

        /// <inheritdoc />
        public Task RunAsync(string[] args)
        {
            CommandLineApplication cmdApp = new(throwOnUnexpectedArg: false);

            CommandOption grossAmount = cmdApp.Option(Messages.GrossAmountOption, Messages.GrossAmountHint, CommandOptionType.SingleValue);
            CommandOption currency = cmdApp.Option(
                Messages.CurrencyOption,
                Messages.GetCurrencyHint(_appConfig.DefaultCurrencyCode),
                CommandOptionType.SingleValue);
            cmdApp.HelpOption(Messages.HelpOption);

            cmdApp.OnExecute(() =>
            {
                if (grossAmount.HasValue())
                {
                    Salary grossSalary = _salaryService.BuildSalary(grossAmount.Value(), currency.Value());
                    Salary netSalary = _salaryService.GetNetSalary(grossSalary);

                    Console.WriteLine(Messages.GetResult(netSalary));
                }

                return 0;
            });

            cmdApp.Execute(args);
            return Task.CompletedTask;
        }
    }
}
