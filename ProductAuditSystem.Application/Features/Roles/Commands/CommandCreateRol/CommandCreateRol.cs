using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandCreateRol;

public class CommandCreateRol : IRequest<BaseCommandResponse>
{
    public string RolNombre { get; set; } = string.Empty;
}
