using System.Collections.Generic;
using Newtonsoft.Json;

namespace Invest.Infra.Funds
{
    public class RecoverInvestmentDto
    {
        [JsonProperty("fundos")]
        public IList<InvestmentDto> Investments { get; set; }

        public RecoverInvestmentDto()
        {
            Investments = new List<InvestmentDto>();
        }
    }
}