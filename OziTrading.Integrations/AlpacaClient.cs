using Alpaca.Markets;
using OziTrading.Integrations.Alpaca.Interfaces;
using OziTrading.Integrations.Models;
using System;
using System.Threading.Tasks;

namespace OziTrading.Integrations
{
    public class AlpacaClient : IAlpacaClient
    {
        private readonly IAlpacaConfigurations _config;

        public AlpacaClient(AlpacaConfigurations config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

        }

        public async Task<AlpacaAccountModel> GetAccountAsync()
        {
            var account = await AlpacaTradingClient().GetAccountAsync();


            return new AlpacaAccountModel() {
                Id = account.AccountId,
                AccountantNumber = account.AccountNumber,
                Currency = account.Currency,
                TradableCash = account.TradableCash,
                WithdrawableCash = account.WithdrawableCash,
                Status = account.Status.ToString()
            };
        }

        private AlpacaTradingClient AlpacaTradingClient() => Environments.Paper.GetAlpacaTradingClient(new SecretKey(_config.ApiKeyId, _config.ApiSecretKey));

    }
}
