
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.UpdateSupportDeparment;

public class CommandUpdateSupportDepartment : IRequest<BaseCommandResponse>
{
    public int Id { get; set; } 
    public string Department { get; set; } = string.Empty;
}
