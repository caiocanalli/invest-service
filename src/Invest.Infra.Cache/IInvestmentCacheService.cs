using System.Threading.Tasks;

namespace Invest.Infra.Cache
{
    public interface IInvestmentCacheService
    {
        Task<RecoverInvestmentCacheDto> Recover(int customerId);
        Task Store(int customerId, RecoverInvestmentCacheDto dto);
    }
}