namespace Invest.Domain.Investments
{
    public class FundsIncomeTaxesPolicy : IncomeTaxesPolicy
    {
        const decimal Tax = 0.15m;

        public override decimal CalcIncomeTaxes(Investment investment)
        {
            var profitability = investment.TotalValue - investment.InvestedValue;
            return profitability > 0 ? profitability * Tax : 0;
        }
    }
}