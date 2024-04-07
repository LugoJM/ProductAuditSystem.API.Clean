using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandDeleteRol;

public record CommandDeleteRol(int Id) : IRequest<BaseCommandResponse>;
