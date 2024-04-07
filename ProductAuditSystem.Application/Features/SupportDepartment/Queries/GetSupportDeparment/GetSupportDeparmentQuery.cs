
using MediatR;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparment;

public record GetSupportDeparmentQuery(int Id) : IRequest<GetSupportDeparmentDTO>;