using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Invest.Application.Common;
using Invest.Application.Investments;
using Microsoft.AspNetCore.Mvc;

namespace Invest.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        readonly IInvestmentAppService _investmentAppService;

        public InvestmentController(IInvestmentAppService investmentAppService)
        {
            _investmentAppService = investmentAppService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(422)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Recover([Required][FromQuery] int customerId)
        {
            var result = await _investmentAppService.Recover(customerId);
            if (result.Success)
                return Ok(result.Value);
            if (result.Error == Errors.Domain.UnprocessableEntity())
                return UnprocessableEntity();
            return BadRequest();
        }
    }
}