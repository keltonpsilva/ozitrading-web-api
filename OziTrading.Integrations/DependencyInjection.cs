using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OziTrading.Integrations.Alpaca.Interfaces;

namespace OziTrading.Integrations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var alpacaConfigurations = new AlpacaConfigurations();
            configuration.Bind(nameof(alpacaConfigurations), alpacaConfigurations);
            services.AddSingleton(alpacaConfigurations);

            AddIoC(services);

            return services;
        }

        private static void AddIoC(IServiceCollection services)
        {
            services.AddScoped<IAlpacaClient, AlpacaClient>();
        }
    }
}
