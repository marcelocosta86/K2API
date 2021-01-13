using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K2.Desafio.Application.Accounting.GetInterestRate
{
    public class GetInterestRatetHandler : IRequestHandler<GetInterestRateQuery, InterestRateDto>
    {
        public async Task<InterestRateDto> Handle(GetInterestRateQuery request, CancellationToken cancellationToken)
        {
            var data = new InterestRateDto()
            {
                InterestRateValue = 0.01
            };

            return data;
        }
    }
}
