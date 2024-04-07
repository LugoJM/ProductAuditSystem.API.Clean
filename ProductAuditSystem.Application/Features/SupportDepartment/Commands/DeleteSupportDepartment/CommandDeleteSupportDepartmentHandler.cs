
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.DeleteSupportDepartment;

internal sealed class CommandDeleteSupportDepartmentHandler : IRequestHandler<CommandDeleteSupportDepartment, BaseCommandResponse>
{
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;

    public CommandDeleteSupportDepartmentHandler(ISupportDepartmentRepository supportDepartmentRepository)
    {
        _supportDepartmentRepository = supportDepartmentRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteSupportDepartment request, CancellationToken cancellationToken)
    {
        var deleteSupportDepartment = await _supportDepartmentRepository.GetByIdAsync(request.Id);

        if (deleteSupportDepartment == null)
            throw new NotFoundException(nameof(deleteSupportDepartment), request.Id);

        await _supportDepartmentRepository.DeleteAsync(deleteSupportDepartment);

        return new BaseCommandResponse
        {
            Id = deleteSupportDepartment.Id,
            Message = $"Se ha eliminado el Departamento con ID:{request.Id}",
            Success = true
        };
    }
}
