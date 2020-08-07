using Microsoft.AspNetCore.Mvc;
using OziTrading.Integrations.Alpaca.Interfaces;
using System.Threading.Tasks;

namespace OziTrading.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssestsController : ControllerBase
    {
        private readonly IAlpacaClient _alpacaClient;

        public AssestsController(IAlpacaClient alpacaClient)
        {
            _alpacaClient = alpacaClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var assests = await _alpacaClient.GetListAssestsAsync();

            if (assests is null) {
                return NotFound();
            }

            return Ok(assests);
        }

        [HttpGet]
        [Route("{symbol}")]
        public async Task<IActionResult> GetBySymbol(string symbol)
        {
            var assest = await _alpacaClient.GetAssestAsyncBySymbolAsync(symbol);

            if (assest is null) {
                return NotFound();
            }

            return Ok(assest);
        }
    }
}