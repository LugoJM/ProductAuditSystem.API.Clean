using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAuditSystem.Application.Contracts.Infrastructure.ActiveDirectory;
using ProductAuditSystem.Application.Contracts.Infrastructure.JSONFileService;
using ProductAuditSystem.Infrastructure.ActiveDirectory;
using ProductAuditSystem.Infrastructure.JsonFileService;

namespace ProductAuditSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IActiveDirectory, ActiveDirectoryService>();
            services.AddTransient<IJsonFileService, JSONFileService>();
            return services;
        }
    }
}
