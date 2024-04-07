
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

    public CommandUpdateUserHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateUser request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            throw new NotFoundException(nameof(user), request.Id);

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
