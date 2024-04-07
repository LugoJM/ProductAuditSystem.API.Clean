

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Persistence.Configurations;

internal class RolesConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.HasData(
        new Rol
        {
            Id = 1,
            RolNombre = "ADMIN",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
        },
        new Rol
        {
            Id = 2,
            RolNombre = "NORMAL",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
        },
        new Rol
        {
            Id = 3,
            RolNombre = "AUDITOR",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
        });
    }
}
