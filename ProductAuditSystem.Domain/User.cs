using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int RolID { get; set; }
    public string Correo { get; set; } = string.Empty;
    public virtual Rol? Rol { get; set; }

    public virtual ICollection<AuditUser>? UsuarioAuditorias { get; set; }
}


