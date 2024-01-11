namespace Application.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using Application.Interfaces;
    using Application.Services;
    using Domain.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Infrastructure.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();

            services.AddDomainDependencies();

            services.AddInfrastructureDependencies(configuration);

            // Infrastructure
            services.AddInfrastructure();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPaperMoneyService, PaperMoneyService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IWithdrawService, WithdrawService>();
            return services;
        }
    }
}
