using Invest.Infra.DirectTreasury;
using Invest.Infra.FixedIncome;
using Invest.Infra.Funds;
using Microsoft.Extensions.DependencyInjection;

namespace Invest.Infra.IoC
{
    public static class DomainDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IDirectTreasuryService, DirectTreasuryService>();
            services.AddScoped<IFixedIncomeService, FixedIncomeService>();
            services.AddScoped<IFundsService, FundsService>();
        }
    }
}