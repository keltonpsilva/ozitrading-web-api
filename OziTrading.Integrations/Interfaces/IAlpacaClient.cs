using OziTrading.Integrations.Models;
using System.Threading.Tasks;

namespace OziTrading.Integrations.Alpaca.Interfaces
{
    public interface IAlpacaClient
    {
        Task<AlpacaAccountModel> GetAccountAsync();
    }
}
