namespace Invest.Domain.Investments
{
    public class TreasuryDirectPolicyIncomeTaxes : IncomeTaxesPolicy
    {
        const decimal Tax = 0.10m;

        public override decimal CalcIncomeTaxes(Investment investment)
        {
            var profitability = investment.TotalValue - investment.InvestedValue;
            return profitability > 0 ? profitability * Tax : 0;
        }
    }
}