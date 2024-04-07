
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.DeletePointStatus;

internal sealed class CommandDeletePointStatusHandler : IRequestHandler<CommandDeletePointStatus, BaseCommandResponse>
{
    private readonly IPointStatusRepository _pointStatusRepository;

    public CommandDeletePointStatusHandler(IPointStatusRepository pointStatusRepository)
    {
        _pointStatusRepository = pointStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeletePointStatus request, CancellationToken cancellationToken)
    {
        var pointToDelete = await _pointStatusRepository.GetByIdAsync(request.Id);

        if (pointToDelete == null)
            throw new NotFoundException(nameof(pointToDelete), request.Id);

        await _pointStatusRepository.DeleteAsync(pointToDelete);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha eliminado el Point Status con ID:{request.Id}",
            Success = true
        };
    }
}
