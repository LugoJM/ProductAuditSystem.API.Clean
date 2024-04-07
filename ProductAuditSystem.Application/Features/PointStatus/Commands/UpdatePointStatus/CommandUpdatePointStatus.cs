
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.UpdatePointStatus;

public class CommandUpdatePointStatus : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
