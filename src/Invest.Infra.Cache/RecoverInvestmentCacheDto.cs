using System.Collections.Generic;

namespace Invest.Infra.Cache
{
    public class RecoverInvestmentCacheDto
    {
        public decimal TotalValue { get; set; }
        public List<InvestmentCacheDto> Investments { get; set; }
    }
}