using MediatR;

namespace ProductAuditSystem.Application.Features.Audit.Queries.GetAudit;

public record GetAuditQuery(int ID) : IRequest<GetAuditDTO>;
