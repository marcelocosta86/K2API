using K2.Desafio.Application.Accounting.GetCalculateInterest;
using K2.Desafio.Application.Accounting.GetInterestRate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace K2.Desafio.API.Accounting
{
    [Route("api")]
    [ApiController]
    [AllowAnonymous]
    public class AccountingController : Controller
    {
        private readonly IMediator _mediator;

        public AccountingController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("taxaJuros")]
        [HttpGet]
        [ProducesResponseType(typeof(InterestRateDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInterestRate()
        {
            var dados = await _mediator.Send(new GetInterestRateQuery());
            return Ok(dados);
        }


        [Route("calculajuros")]
        [HttpGet]
        [ProducesResponseType(typeof(CalculateInterestDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReportDailyRedemption(
            [FromQuery] decimal initialvalue,
            [FromQuery] int numberMonths)
        {
            var dados = await _mediator.Send(new GetCalculateInterestQuery(double.Parse(initialvalue.ToString()), numberMonths));

            return Ok(dados);
        }
    }
}
