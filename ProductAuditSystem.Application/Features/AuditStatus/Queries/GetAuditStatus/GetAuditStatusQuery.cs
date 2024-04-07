
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditStatus;

public record GetAuditStatusQuery(int Id) : IRequest<AuditStatusDTO>;