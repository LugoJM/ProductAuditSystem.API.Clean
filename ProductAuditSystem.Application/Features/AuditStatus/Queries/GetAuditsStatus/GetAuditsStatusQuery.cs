
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditsStatus;

public record GetAuditsStatusQuery : IRequest<List<AuditStatusDTO>>;
