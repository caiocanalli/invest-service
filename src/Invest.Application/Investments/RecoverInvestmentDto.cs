using System.Collections.Generic;
using Newtonsoft.Json;

namespace Invest.Application.Investments
{
    public class RecoverInvestmentDto
    {
        [JsonProperty("valorTotal")]
        public decimal TotalValue { get; set; }

        [JsonProperty("investimentos")]
        public List<InvestmentDto> Investments { get; set; }
    }
}