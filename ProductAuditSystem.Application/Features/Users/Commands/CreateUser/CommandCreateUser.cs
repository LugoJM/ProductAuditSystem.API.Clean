
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Users.Commands.CreateUser;

public class CommandCreateUser : IRequest<BaseCommandResponse>
{
    public string Username { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public int RolID { get; set; }

    public string Correo { get; set; } = string.Empty;
}
