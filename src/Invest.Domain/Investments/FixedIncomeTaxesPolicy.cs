namespace Invest.Domain.Investments
{
    public class FixedIncomeTaxesPolicy : IncomeTaxesPolicy
    {
        const decimal Tax = 0.05m;

        public override decimal CalcIncomeTaxes(Investment investment)
        {
            var profitability = investment.TotalValue - investment.InvestedValue;
            return profitability > 0 ? profitability * Tax : 0;
        }
    }
}