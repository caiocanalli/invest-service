using System.Collections.Generic;
using System.Linq;
using Invest.Domain.Investments;

namespace Invest.Infra.FixedIncome
{
    public class InvestmentAdpater
    {
        public IReadOnlyList<Investment> ToInvestment(RecoverInvestmentDto dto) =>
            dto.Investments.Select(x =>
                    new Investment(
                        x.Name,
                        x.InvestedCapital,
                        x.ActualCapital,
                        x.DueDate,
                        new FixedIncomeTaxesPolicy()))
                .ToList()
                .AsReadOnly();
    }
}