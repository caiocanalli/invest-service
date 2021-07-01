using System.Collections.Generic;
using Newtonsoft.Json;

namespace Invest.Infra.DirectTreasury
{
    public class RecoverInvestmentDto
    {
        [JsonProperty("tds")]
        public IList<InvestmentDto> Investments { get; set; }

        public RecoverInvestmentDto()
        {
            Investments = new List<InvestmentDto>();
        }
    }
}