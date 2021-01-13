using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace K2.Desafio.Application.Accounting.GetCalculateInterest
{
    public class GetCalculateInterestQuery : IRequest<CalculateInterestDto>
    {
        public double Initialvalue { get; set; }
        public int NumberMonths { get; set; }

        public GetCalculateInterestQuery(double initialvalue, int NumberMonths)
        {
            this.Initialvalue = initialvalue;
            this.NumberMonths = NumberMonths;
        }
    }
}
