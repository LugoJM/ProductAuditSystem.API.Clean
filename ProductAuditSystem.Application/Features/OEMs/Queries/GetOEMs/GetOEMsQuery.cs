
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.OEMs.Queries.GetOEMs;

public record GetOEMsQuery : IRequest<List<OEM_DTO>>;
