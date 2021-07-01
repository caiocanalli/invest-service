using System.Collections.Generic;
using Newtonsoft.Json;

namespace Invest.Infra.FixedIncome
{
    public class RecoverInvestmentDto
    {
        [JsonProperty("lcis")]
        public IList<InvestmentDto> Investments { get; set; }

        public RecoverInvestmentDto()
        {
            Investments = new List<InvestmentDto>();
        }
    }
}