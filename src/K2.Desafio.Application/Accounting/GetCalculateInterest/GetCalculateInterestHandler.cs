using K2.Desafio.Application.Accounting.GetInterestRate;
using K2.Desafio.Application.Extension;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K2.Desafio.Application.Accounting.GetCalculateInterest
{
    public class GetCalculateInterestHandler : IRequestHandler<GetCalculateInterestQuery, CalculateInterestDto>
    {
        static readonly HttpClient client = new HttpClient();

        private double GetInterestRateApiAsync()
        {
            var json = RequestHttp.Get("https://localhost:44343/api/taxaJuros");
            var obj = JsonConvert.DeserializeObject<InterestRateDto>(json);
            return obj.InterestRateValue;
        }

        private string CalculateInterest(double initialValue, int months)
        {
            var interest = GetInterestRateApiAsync();
            var valueFuture = initialValue * Math.Pow(interest + 1, months); 
            return valueFuture.ToString("C2");
        }

        public async Task<CalculateInterestDto> Handle(GetCalculateInterestQuery request, CancellationToken cancellationToken)
        {
            var data = new CalculateInterestDto()
            {
                FutureValue = CalculateInterest(request.Initialvalue, request.NumberMonths)
            };
            return data;
        }
    }
}
