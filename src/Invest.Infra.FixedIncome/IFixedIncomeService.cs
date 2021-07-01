using System.Collections.Generic;
using System.Threading.Tasks;
using Invest.Domain.Investments;

namespace Invest.Infra.FixedIncome
{
    public interface IFixedIncomeService
    {
        Task<IReadOnlyList<Investment>> RecoverInvestment();
    }
}