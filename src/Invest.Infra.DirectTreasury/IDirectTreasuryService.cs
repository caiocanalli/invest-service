using System.Collections.Generic;
using System.Threading.Tasks;
using Invest.Domain.Investments;

namespace Invest.Infra.DirectTreasury
{
    public interface IDirectTreasuryService
    {
        Task<IReadOnlyList<Investment>> RecoverInvestment();
    }
}