
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Users.Queries.GetUsersQuery;

public record GetUsersQuery : IRequest<List<UserDTO>>;