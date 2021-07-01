using Invest.Application.Investments;
using Microsoft.Extensions.DependencyInjection;

namespace Invest.Infra.IoC
{
    public static class ApplicationDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IInvestmentAppService, InvestmentAppService>();
        }
    }
}