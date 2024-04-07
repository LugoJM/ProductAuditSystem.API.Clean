
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointStatus;

public record GetPointStatusQuery(int Id) : IRequest<PointStatusDTO>;
