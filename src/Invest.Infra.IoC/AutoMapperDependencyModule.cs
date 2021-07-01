using AutoMapper;
using Invest.Application.Investments;
using Invest.Infra.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Invest.Infra.IoC
{
    public static class AutoMapperDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new InvestmentMapper());
                mc.AddProfile(new InvestmentCacheMapper());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}