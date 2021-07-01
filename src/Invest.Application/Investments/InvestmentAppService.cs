using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Invest.Application.Common;
using Invest.Domain.Common;
using Invest.Domain.Investments;
using Invest.Infra.Cache;
using Invest.Infra.DirectTreasury;
using Invest.Infra.FixedIncome;
using Invest.Infra.Funds;
using Microsoft.Extensions.Logging;

namespace Invest.Application.Investments
{
    public class InvestmentAppService : IInvestmentAppService
    {
        readonly IMapper _mapper;
        private readonly ILogger<InvestmentAppService> _logger;
        readonly IInvestmentCacheService _investmentCacheService;
        readonly IDirectTreasuryService _directTreasuryService;
        readonly IFixedIncomeService _fixedIncomeService;
        readonly IFundsService _fundsService;

        public InvestmentAppService(
            IMapper mapper,
            ILogger<InvestmentAppService> logger,
            IInvestmentCacheService investmentCacheService,
            IDirectTreasuryService directTreasuryService,
            IFixedIncomeService fixedIncomeService,
            IFundsService fundsService)
        {
            _mapper = mapper;
            _logger = logger;
            _investmentCacheService = investmentCacheService;
            _directTreasuryService = directTreasuryService;
            _fixedIncomeService = fixedIncomeService;
            _fundsService = fundsService;
        }

        public async Task<Result<RecoverInvestmentDto>> Recover(int customerId)
        {
            try
            {
                var cacheDto = await _investmentCacheService.Recover(customerId);
                if (cacheDto != null)
                    return Result.Ok(_mapper.Map<RecoverInvestmentDto>(cacheDto));

                var tasks = new List<Task<IReadOnlyList<Investment>>>
                {
                    _directTreasuryService.RecoverInvestment(),
                    _fixedIncomeService.RecoverInvestment(),
                    _fundsService.RecoverInvestment()
                };
                var results = await Task.WhenAll(tasks);
                var investments = results.SelectMany(list => list).ToList();

                cacheDto = _mapper.Map<RecoverInvestmentCacheDto>(investments);
                await _investmentCacheService.Store(customerId, cacheDto);

                var response = _mapper.Map<RecoverInvestmentDto>(
                    results.SelectMany(list => list).ToList());

                return Result.Ok(response);
            }
            catch (DomainException exception)
            {
                _logger.LogInformation("Error on recover investments");
                
                return Result.Fail<RecoverInvestmentDto>(
                    Errors.Domain.UnprocessableEntity(exception.Message));
            }
        }
    }
}