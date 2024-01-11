namespace Domain.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Interfaces;
    using Domain.Services;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddDomainServices();

            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Domain Services
            services.AddTransient<IWithdrawManager, WithdrawManager>();
            return services;
        }
    }
}