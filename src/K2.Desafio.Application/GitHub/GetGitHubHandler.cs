using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K2.Desafio.Application.Accounting.GitHub
{
    public class GetGitHubHandler : IRequestHandler<GetGitHubQuery, GitHubDto>
    {
        public async Task<GitHubDto> Handle(GetGitHubQuery request, CancellationToken cancellationToken)
        {
            var data = new GitHubDto()
            {
                Url = "https://github.com/marcelocosta86/K2API.git"
            };

            return data;
        }
    }
}
