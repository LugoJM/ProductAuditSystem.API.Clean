namespace ProductAuditSystem.Application.Common.SharedDTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public RolDTO? Rol { get; set; }
}