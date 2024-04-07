using MediatR;


namespace ProductAuditSystem.Application.Features.Roles.Queries.GetRoles;

public record GetRolesQuery : IRequest<List<GetRolDTO>>;