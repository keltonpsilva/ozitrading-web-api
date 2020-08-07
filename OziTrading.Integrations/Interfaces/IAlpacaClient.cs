using OziTrading.Integrations.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OziTrading.Integrations.Alpaca.Interfaces
{
    public interface IAlpacaClient
    {
        Task<AlpacaAccountModel> GetAccountAsync();
        Task<List<AlpacaAssestModel>> GetListAssestsAsync();
        Task<AlpacaAssestModel> GetAssestAsyncByIdAsync(string id);
        Task<AlpacaAssestModel> GetAssestAsyncBySymbolAsync(string symbol);
    }
}
