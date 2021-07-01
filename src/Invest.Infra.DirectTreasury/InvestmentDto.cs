using System;
using Newtonsoft.Json;

namespace Invest.Infra.DirectTreasury
{
    public class InvestmentDto
    {
        [JsonProperty("valorInvestido")]
        public decimal InvestedValue { get; set; }

        [JsonProperty("valorTotal")]
        public decimal TotalValue { get; set; }

        [JsonProperty("vencimento")]
        public DateTime DueDate { get; set; }

        [JsonProperty("dataDeCompra")]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty("iof")]
        public string Iof { get; set; }

        [JsonProperty("indice")]
        public string Index { get; set; }

        [JsonProperty("tipo")]
        public string Type { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }
    }
}