
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandDeleteAuditStatus;

public record CommandDeleteAuditStatus(int Id) : IRequest<BaseCommandResponse>;
