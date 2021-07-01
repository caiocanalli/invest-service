using System;

namespace Invest.Infra.Cache
{
    public class InvestmentCacheDto
    {
        public string Name { get; set; }
        public decimal InvestedValue { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime DueDate { get; set; }
        public decimal IncomeTaxes { get; set; }
        public decimal RescueValue { get; set; }
    }
}