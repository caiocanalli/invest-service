using System.Collections.Generic;
using System.Threading.Tasks;
using Invest.Domain.Investments;

namespace Invest.Infra.Funds
{
    public interface IFundsService
    {
        Task<IReadOnlyList<Investment>> RecoverInvestment();
    }
}