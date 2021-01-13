using K2.Desafio.Application.Accounting.GitHub;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace K2.Desafio.API.GitHub
{
    [Route("api")]
    [ApiController]
    [AllowAnonymous]
    public class GitHubController : Controller
    {
        private readonly IMediator _mediator;

        public GitHubController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("showmethecode")]
        [HttpGet]
        [ProducesResponseType(typeof(GitHubDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInterestRate()
        {
            var dados = await _mediator.Send(new GetGitHubQuery());
            return Ok(dados);
        }
    }
}
