using Microsoft.Extensions.DependencyInjection;

namespace Invest.Infra.IoC
{
    public static class DependencyServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            ApplicationDependencyModule.RegisterDependencies(services);
            AutoMapperDependencyModule.RegisterDependencies(services);
            CacheDependencyModule.RegisterDependencies(services);
            DomainDependencyModule.RegisterDependencies(services);
        }
    }
}