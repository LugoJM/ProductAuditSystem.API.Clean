
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.DeleteSupportDepartment;

public record CommandDeleteSupportDepartment(int Id) : IRequest<BaseCommandResponse>;
