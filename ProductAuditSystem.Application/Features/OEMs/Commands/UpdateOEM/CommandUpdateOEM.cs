
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.UpdateOEM;

public class CommandUpdateOEM : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
