using System;
using Newtonsoft.Json;

namespace Invest.Application.Investments
{
    public class InvestmentDto
    {
        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("valorInvestido")]
        public decimal InvestedValue { get; set; }

        [JsonProperty("valorTotal")]
        public decimal TotalValue { get; set; }

        [JsonProperty("vencimento")]
        public DateTime DueDate { get; set; }

        [JsonProperty("Ir")]
        public decimal IncomeTaxes { get; set; }

        [JsonProperty("valorResgate")]
        public decimal RescueValue { get; set; }
    }
}