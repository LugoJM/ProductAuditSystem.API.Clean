
using MediatR;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparments;

public record GetSupportDeparmentsQuery : IRequest<List<GetSupportDeparmentDTO>>;
