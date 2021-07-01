using System.Collections.Generic;
using System.Linq;
using Invest.Domain.Investments;

namespace Invest.Infra.Funds
{
    public class InvestmentAdpater
    {
        public IReadOnlyList<Investment> ToInvestment(RecoverInvestmentDto dto) =>
            dto.Investments.Select(x =>
                    new Investment(
                        x.Name,
                        x.InvestedCapital,
                        x.ActualValue,
                        x.RescueDate,
                        new FundsIncomeTaxesPolicy()))
                .ToList()
                .AsReadOnly();
    }
}