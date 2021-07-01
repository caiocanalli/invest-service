using System;
using Newtonsoft.Json;

namespace Invest.Infra.FixedIncome
{
    public class InvestmentDto
    {
        [JsonProperty("capitalInvestido")]
        public decimal InvestedCapital { get; set; }

        [JsonProperty("capitalAtual")]
        public decimal ActualCapital { get; set; }

        [JsonProperty("quantidade")]
        public double Quantity { get; set; }

        [JsonProperty("vencimento")]
        public DateTime DueDate { get; set; }

        [JsonProperty("iof")]
        public decimal Iof { get; set; }

        [JsonProperty("outrasTaxas")]
        public decimal OtherTaxes { get; set; }

        [JsonProperty("taxas")]
        public decimal Taxes { get; set; }

        [JsonProperty("indice")]
        public string Index { get; set; }

        [JsonProperty("tipo")]
        public string Type { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("guarantidoFGC")]
        public bool FGCGuarantee { get; set; }

        [JsonProperty("dataOperacao")]
        public DateTime OperationDate { get; set; }

        [JsonProperty("precoUnitario")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("primario")]
        public bool Primary { get; set; }
    }
}