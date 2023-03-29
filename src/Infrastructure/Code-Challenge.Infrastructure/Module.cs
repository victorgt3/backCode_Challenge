using Code_Challenge.Application.Interface;
using Code_Challenge.Domain.Interface;
using Code_Challenge.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Code_Challenge.Infrastructure
{
    public static class Module
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration) 
        {
            var url = configuration.GetSection("UrlSMK186").Get<string>();

            services.AddHttpClient("SMK186", (options) =>
            {
                options.BaseAddress = new Uri(url);
            });

            services.AddTransient<ISMK186Repository, SMK186Repository>();

            return services;
        }
    }
}
