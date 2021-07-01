using System.Threading.Tasks;
using Invest.Application.Common;

namespace Invest.Application.Investments
{
    public interface IInvestmentAppService
    {
        Task<Result<RecoverInvestmentDto>> Recover(int customerId);
    }
}