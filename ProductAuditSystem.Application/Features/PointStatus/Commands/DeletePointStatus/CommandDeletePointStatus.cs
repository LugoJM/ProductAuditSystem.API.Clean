
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.DeletePointStatus;

public record CommandDeletePointStatus(int Id) : IRequest<BaseCommandResponse>;