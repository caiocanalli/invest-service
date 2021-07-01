namespace Invest.Domain.Investments
{
    public abstract class IncomeTaxesPolicy
    {
        public abstract decimal CalcIncomeTaxes(Investment investment);
    }
}