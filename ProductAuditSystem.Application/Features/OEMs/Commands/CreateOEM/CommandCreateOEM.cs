
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.CreateOEM;

public class CommandCreateOEM : IRequest<BaseCommandResponse>
{
    public string Nombre { get; set; } = string.Empty;
}
