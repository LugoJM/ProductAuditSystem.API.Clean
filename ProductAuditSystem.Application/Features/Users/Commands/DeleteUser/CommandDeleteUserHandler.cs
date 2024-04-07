
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Users.Commands.DeleteUser;

internal sealed class CommandDeleteUserHandler : IRequestHandler<CommandDeleteUser, BaseCommandResponse>
{
    private readonly IUserRepository _userRepository;

    public CommandDeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteUser request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);

        if (userToDelete == null)
            throw new NotFoundException(nameof(userToDelete), request.Id);

        await _userRepository.DeleteAsync(userToDelete);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha eliminado el usuario con ID:{request.Id}",
            Success = true,
        };
    }
}
