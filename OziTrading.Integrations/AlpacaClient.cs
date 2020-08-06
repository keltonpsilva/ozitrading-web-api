using OziTrading.Integrations.Alpaca.Interfaces;
using System;

namespace OziTrading.Integrations
{
    public class AlpacaClient : IAlpacaClient
    {
        private readonly IAlpacaConfigurations _config;

        public AlpacaClient(AlpacaConfigurations config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }


    }
}
