
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointsStatus;

public record GetPointsStatusQuery : IRequest<List<PointStatusDTO>>;
