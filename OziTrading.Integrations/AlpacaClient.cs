using Alpaca.Markets;
using OziTrading.Integrations.Alpaca.Interfaces;
using OziTrading.Integrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<AlpacaAssestModel> GetAssestAsyncByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AlpacaAssestModel> GetAssestAsyncBySymbolAsync(string symbol)
        {
            var assest = await AlpacaTradingClient().GetAssetAsync(symbol.ToUpper());

            return new AlpacaAssestModel() {
                Class = assest.Class.ToString(),
                EasyToBorrow = assest.EasyToBorrow,
                Exchange = assest.Exchange.ToString(),
                Id = assest.AssetId,
                Marginable = assest.Marginable,
                Shortable = assest.Shortable,
                Status = assest.Status.ToString(),
                Symbol = assest.Symbol,
                Tradable = assest.IsTradable
            };
        }

        public async Task<List<AlpacaAssestModel>> GetListAssestsAsync()
        {
            var assets = await AlpacaTradingClient().ListAssetsAsync(new AssetsRequest() { AssetStatus = AssetStatus.Active });

            return assets.Select(a => new AlpacaAssestModel() {
                Id = a.AssetId,
                Class = a.Class.ToString(),
                EasyToBorrow = a.EasyToBorrow,
                Exchange = a.Exchange.ToString(),
                Marginable = a.Marginable,
                Shortable = a.Shortable,
                Status = a.Status.ToString(),
                Symbol = a.Symbol,
                Tradable = a.IsTradable,
            }).ToList();

        }

        private AlpacaTradingClient AlpacaTradingClient() => Environments.Paper.GetAlpacaTradingClient(new SecretKey(_config.ApiKeyId, _config.ApiSecretKey));

    }
}
