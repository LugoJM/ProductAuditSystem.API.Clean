using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Persistence.DataBaseContext;
using ProductAuditSystem.Persistence.Repositories;

namespace ProductAuditSystem.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductAuditSystemDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IAuditRepository, AuditRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IPointStatusRepository, PointStatusRepository>();
        services.AddScoped<IOEMsRepository, OEMRepository>();
        services.AddScoped<IEvaluationPointRepository, EvaluationPointRepository>();
        services.AddScoped<IAuditStatusRepository, AuditStatusRepository>();
        services.AddScoped<ISupportDepartmentRepository, SupportDeparmentRepository>();
        services.AddScoped<IAuditQuestionRepository, AuditQuestionRepository>();
        services.AddScoped<IAuditUserRepository, AuditUserRepository>();
        services.AddScoped<IFilesRepository, FilesRepository>();
        return services;
    }
}
