
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.CreateSupportDepartment;

public class CommandCreateSupportDepartment : IRequest<BaseCommandResponse>
{
    public string Department { get; set; } = string.Empty;
}
