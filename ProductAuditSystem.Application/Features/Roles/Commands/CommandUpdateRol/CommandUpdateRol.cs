using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;

public class CommandUpdateRol : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public string RolNombre { get; set; } = string.Empty;
}
