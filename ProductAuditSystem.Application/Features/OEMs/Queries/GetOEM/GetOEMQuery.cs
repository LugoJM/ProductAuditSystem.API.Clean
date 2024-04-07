
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.OEMs.Queries.GetOEM;

public record GetOEMQuery(int Id) : IRequest<OEM_DTO>;

