using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OziTrading.Integrations.Alpaca.Interfaces;
using OziTrading.Integrations.Models;
using System.Threading.Tasks;

namespace OziTrading.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAlpacaClient _alpacaClient;

        public AccountController(IAlpacaClient alpacaClient)
        {
            _alpacaClient = alpacaClient;
        }


        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlpacaAccountModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountant()
        {
            var alpacaAccount = await _alpacaClient.GetAccountAsync();

            if (alpacaAccount is null) {
                return NotFound();
            }

            return Ok(alpacaAccount);
        }
    }
}