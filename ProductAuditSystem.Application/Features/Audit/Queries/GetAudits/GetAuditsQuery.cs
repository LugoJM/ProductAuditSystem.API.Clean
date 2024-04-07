using MediatR;

namespace ProductAuditSystem.Application.Features.Audit.Queries.GetAudits;

public record GetAuditsQuery : IRequest<List<GetAuditsDTO>>;
