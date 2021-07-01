using Invest.Infra.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Invest.Infra.IoC
{
    public static class CacheDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<IInvestmentCacheService, InvestmentCacheService>();
        }
    }
}