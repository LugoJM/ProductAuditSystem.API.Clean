using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Persistence.DataBaseContext
{
    public class ProductAuditSystemDBContext : DbContext
    {
        public ProductAuditSystemDBContext(DbContextOptions<ProductAuditSystemDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<EvaluationPoint> EvaluationPoints { get; set; }
        public DbSet<PointStatus> PointStatus { get; set; }
        public DbSet<OEM> OEMs { get; set; }
        public DbSet<AuditStatus> AuditStatus { get; set; }
        public DbSet<SupportDepartment> SupportDepartment { get; set; }
        public DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductAuditSystemDBContext).Assembly);
            base.OnModelCreating(modelBuilder);

            //Relaciones muchos a muchos entre Auditoria y Usuarios utilizando UsuarioAuditoria
            modelBuilder.Entity<AuditUser>()
                .HasKey(ua => new { ua.UsuarioID, ua.AuditoriaID });

            modelBuilder.Entity<AuditUser>()
                .HasOne(ua => ua.Usuario)
                .WithMany(u => u.UsuarioAuditorias)
                .HasForeignKey(ua => ua.UsuarioID);

            modelBuilder.Entity<AuditUser>()
                .HasOne(ua => ua.Auditoria)
                .WithMany(a => a.UsuariosAuditorias)
                .HasForeignKey(ua => ua.AuditoriaID);

            // Relaciones muchos a muchos entre Auditoria y Pregunta utilizando AuditoriaPregunta
            modelBuilder.Entity<AuditQuestion>()
                .HasKey(ap => new { ap.AuditoriaID, ap.PreguntaID });

            modelBuilder.Entity<AuditQuestion>()
                .HasOne(ap => ap.Pregunta)
                .WithMany(p => p.AuditoriasPreguntas)
                .HasForeignKey(ap => ap.PreguntaID);

            modelBuilder.Entity<AuditQuestion>()
                .HasOne(ap => ap.Auditoria)
                .WithMany(a => a.AuditoriasPreguntas)
                .HasForeignKey(ap => ap.AuditoriaID);

            modelBuilder.Entity<Audit>()
                .HasOne(a => a.Status)
                .WithMany()
                .HasForeignKey(a => a.StatusID);

            modelBuilder.Entity<Audit>()
                .HasOne(a => a.OEM)
                .WithMany()
                .HasForeignKey(a => a.OEMID);

            // Relaciones para PuntoEvaluacion
            modelBuilder.Entity<EvaluationPoint>()
                .HasOne(p => p.StatusPunto)
                .WithMany()
                .HasForeignKey(p => p.StatusPuntoID);

            //Relaciones para los archivos con la pregunta
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Files)
                .WithOne(f => f.Question)
                .HasForeignKey(f => f.QuestionID);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.FechaModificacion = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.FechaCreacion = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
