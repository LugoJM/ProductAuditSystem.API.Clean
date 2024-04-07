using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;

public class CommandUpdateRol : IRequest<BaseCommandResponse>
{
    public string Rol { get; set; } = string.Empty;
}
