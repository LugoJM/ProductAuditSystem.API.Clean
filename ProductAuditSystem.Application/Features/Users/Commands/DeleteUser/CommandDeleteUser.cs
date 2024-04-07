
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Users.Commands.DeleteUser;

public record CommandDeleteUser(int Id) : IRequest<BaseCommandResponse>;