
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.Users.Commands.CreateUser;

internal sealed class CommandCreateUserHandler : IRequestHandler<CommandCreateUser, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRolesRepository _rolesRepository;

    public CommandCreateUserHandler(IMapper mapper, IUserRepository userRepository, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _rolesRepository = rolesRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateUser request, CancellationToken cancellationToken)
    {
        var validator = new CommandCreateUserValidator(_rolesRepository,_userRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Crear Usuario Invalido", validationResults);

        var createUser = _mapper.Map<User>(request);

        await _userRepository.CreateAsync(createUser);

        return new BaseCommandResponse
        {
            Id = createUser.Id,
            Message = $"Se ha creado el usuario con ID:{createUser.Id}",
            Success = true
        };
    }
}
