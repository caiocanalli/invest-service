using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Invest.Domain.Investments;
using Microsoft.Extensions.Configuration;
using Polly;

namespace Invest.Infra.Funds
{
    public class FundsService : IFundsService
    {
        readonly string _baseUrl;

        public FundsService(IConfiguration configuration)
        {
            _baseUrl = configuration["Services:Funds"];
        }

        public async Task<IReadOnlyList<Investment>> RecoverInvestment()
        {
            var dto = await Policy
                .Handle<FlurlHttpException>(IsWorthRetrying)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                })
                .ExecuteAsync(() => _baseUrl.GetJsonAsync<RecoverInvestmentDto>());

            return new InvestmentAdpater().ToInvestment(dto);
        }

        private static bool IsWorthRetrying(FlurlHttpException ex) {
            switch (ex.Call.Response.StatusCode) {
                case 408:
                case 500:
                case 502:
                case 504:
                    return true;
                default:
                    return false;
            }
        }
    }
}