using Invest.Infra.IoC;
using Invest.Services.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Invest.Services.Api
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Information($"Checking configurations");
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                Log.Information($"{key}: {value}");
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => 
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter)))
                .AddNewtonsoftJson();

            services.AddHealthChecks();

            services.RegisterDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/api/health");
            });
        }
    }
}