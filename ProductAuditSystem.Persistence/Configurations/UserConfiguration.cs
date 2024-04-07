
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
        new User
        {
            Id = 1,
            Username = "uif87879",
            Nombre = "Lugo Cardenas-EXT, Jose Manuel",
            RolID = 1,
            Correo = "jose.manuel.lugo.cardenas-ext@functionalaccount.com",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now
        }, 
        new User
        {
            Id = 2,
            Username = "AnguloCE",
            Nombre = "Angulo, Cesar",
            RolID = 1,
            Correo = "Cesar.Angulo@continental-corporation.com",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now
        },
        new User
        {
            Id = 3,
            Username = "uib64582",
            Nombre = "MONTANO MOLINA, ROSA VANESSA",
            RolID = 1,
            Correo = "rosa.vanessa.montano@continental-corporation.com",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now
        });
    }
}
