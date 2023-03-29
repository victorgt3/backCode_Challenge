using Code_Challenge.Application.Interface;
using Code_Challenge.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Code_Challenge.Application
{
    public static class Module
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<ISMK186Service, SMK186Service>();

            return services;
        }
    }
}
