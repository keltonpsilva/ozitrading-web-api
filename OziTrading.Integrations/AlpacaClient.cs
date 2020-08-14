using Alpaca.Markets;
using AutoMapper;
using OziTrading.Integrations.Alpaca.Interfaces;
using OziTrading.Integrations.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OziTrading.Integrations
{
    public class AlpacaClient : IAlpacaClient
    {
        private readonly IAlpacaConfigurations _config;
        private readonly IMapper _mapper;

        public AlpacaClient(AlpacaConfigurations config, IMapper mapper)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _mapper = mapper;
        }

        public async Task<AlpacaAccountModel> GetAccountAsync()
        {
            var account = await AlpacaTradingClient().GetAccountAsync();

            return _mapper.Map<AlpacaAccountModel>(account);
        }

        public Task<AlpacaAssestModel> GetAssestAsyncByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AlpacaAssestModel> GetAssestAsyncBySymbolAsync(string symbol)
        {
            var assest = await AlpacaTradingClient().GetAssetAsync(symbol.ToUpper());

            return _mapper.Map<AlpacaAssestModel>(assest);
        }

        public async Task<List<AlpacaAssestModel>> GetListAssestsAsync()
        {
            var assets = await AlpacaTradingClient().ListAssetsAsync(new AssetsRequest() { AssetStatus = AssetStatus.Active });

            return _mapper.Map<List<AlpacaAssestModel>>(assets);
        }

        private AlpacaTradingClient AlpacaTradingClient() => Environments.Paper.GetAlpacaTradingClient(new SecretKey(_config.ApiKeyId, _config.ApiSecretKey));

    }
}
