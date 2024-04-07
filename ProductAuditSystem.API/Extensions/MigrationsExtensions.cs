using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.API.Extensions;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ProductAuditSystemDBContext>();

        dbContext.Database.Migrate();
    }
}
