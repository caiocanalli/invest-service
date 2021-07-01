using System;
using System.Collections.Generic;
using System.Linq;
using Invest.Domain.Investments;

namespace Invest.Infra.DirectTreasury
{
    public class InvestmentAdpater
    {
        public IReadOnlyList<Investment> ToInvestment(RecoverInvestmentDto dto) =>
            dto.Investments.Select(x =>
                    new Investment(
                        x.Name,
                        Convert.ToDecimal(x.InvestedValue),
                        Convert.ToDecimal(x.TotalValue),
                        x.DueDate,
                        new TreasuryDirectPolicyIncomeTaxes()))
                .ToList()
                .AsReadOnly();
    }
}