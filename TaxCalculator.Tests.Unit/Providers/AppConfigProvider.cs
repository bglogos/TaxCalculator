using TaxCalculator.Models.Config;

namespace TaxCalculator.Tests.Unit.Providers
{
    /// <summary>
    /// Provider of fake <see cref="AppConfig"/> instances.
    /// </summary>
    public static class AppConfigProvider
    {
        /// <summary>
        /// Gets fake application configuration.
        /// </summary>
        /// <value>
        /// The application configuration.
        /// </value>
        public static AppConfig AppConfig =>
            new AppConfig
            {
                DefaultCurrencyCode = "idr",
                TaxCalculatorConfig = new TaxCalculatorConfig
                {
                    IdrCalculatorConfig = new IdrCalculatorConfig
                    {
                        NoTaxationThreshold = 10,
                        IncomeTaxPercent = 10,
                        SocialContributionsThreshold = 10,
                        SocialContributionsPercent = 10
                    }
                }
            };
    }
}
