
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Users.Commands.UpdateUser;

internal sealed class CommandUpdateUserHandler : IRequestHandler<CommandUpdateUser, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRolesRepository _rolesRepository;

    public CommandUpdateUserHandler(IMapper mapper, IUserRepository userRepository, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _rolesRepository = rolesRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateUser request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdateUserValidator(_rolesRepository, _userRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Usuario Invalido", validationResults);

        var user = await _userRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, user);

        await _userRepository.UpdateAsync(user);

        return new BaseCommandResponse
        { 
            Id = request.Id,
            Success = true,
            Message = "Se ha editado el usuario correctamente."
        };
    }
}
