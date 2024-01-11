namespace Infrastructure.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Interfaces;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IWithdrawRepository, WithdrawRepository>();
            services.AddScoped<IPaperMoneyRepository, PaperMoneyRepository>();
            return services;
        }
    }
}