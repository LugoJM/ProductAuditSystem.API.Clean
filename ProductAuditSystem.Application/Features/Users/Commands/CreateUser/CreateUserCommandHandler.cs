
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CommandCreateUser, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateUser request, CancellationToken cancellationToken)
    {
        var createUser = _mapper.Map<User>(request);
        var userExists = await _userRepository.CheckUser(createUser);

        if (userExists)
            throw new Exception("Este usuario ya se encuentra registrado!");

        await _userRepository.CreateAsync(createUser);

        return new BaseCommandResponse
        {
            Id = createUser.Id,
            Message = $"Se ha creado el usuario con ID:{createUser.Id}",
            Success = true
        };
    }
}
