
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.DeleteOEM;

public record CommandDeleteOEM(int Id) : IRequest<BaseCommandResponse>;
