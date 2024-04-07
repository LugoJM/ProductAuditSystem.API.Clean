
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Users.Commands.UpdateUser;

public class CommandUpdateUser : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int RolID { get; set; }
    public string Correo { get; set; } = string.Empty;
}
