
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.CreateSupportDepartment;

internal sealed class CommandCreateSupportDepartmentHandler : IRequestHandler<CommandCreateSupportDepartment, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;

    public CommandCreateSupportDepartmentHandler(IMapper mapper, ISupportDepartmentRepository supportDepartmentRepository)
    {
        _mapper = mapper;
        _supportDepartmentRepository = supportDepartmentRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateSupportDepartment request, CancellationToken cancellationToken)
    {
        var validator = new CommandCreateSupportDepartmentValidator(_supportDepartmentRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Crear Departamento De Soporte Invalido", validationResults);

        var createDepartment = _mapper.Map<Domain.SupportDepartment>(request);

        await _supportDepartmentRepository.CreateAsync(createDepartment);

        return new BaseCommandResponse
        {
            Id = createDepartment.Id,
            Message = $"Se ha creado el Departamento con ID:{createDepartment.Id}",
            Success = true,
        };
    }
}
