using MediatR;

namespace ProductAuditSystem.Application.Features.Roles.Queries.GetRol;

public record GetRolQuery(int Id) : IRequest<GetRolDTO>;