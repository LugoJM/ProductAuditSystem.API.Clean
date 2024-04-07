
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Users.Queries.GetUserQuery;

public record GetUserQuery(string Username) : IRequest<UserDTO>;