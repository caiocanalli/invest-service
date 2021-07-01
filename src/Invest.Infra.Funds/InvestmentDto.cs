using System;
using Newtonsoft.Json;

namespace Invest.Infra.Funds
{
    public class InvestmentDto
    {
        [JsonProperty("capitalInvestido")]
        public decimal InvestedCapital { get; set; }

        [JsonProperty("ValorAtual")]
        public decimal ActualValue { get; set; }

        [JsonProperty("dataResgate")]
        public DateTime RescueDate { get; set; }

        [JsonProperty("dataCompra")]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty("iof")]
        public decimal Iof { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("totalTaxas")]
        public decimal TotalTaxes { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}