using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace K2.Desafio.Application.Accounting.GetInterestRate
{
    public class GetInterestRateQuery : IRequest<InterestRateDto>
    {
    }
}
