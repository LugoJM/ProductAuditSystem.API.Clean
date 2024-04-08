using AutoMapper;
using Moq;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;
using ProductAuditSystem.Application.MappingProfiles;
using ProductAuditSystem.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductAuditSystem.Application.UnitTests.Features.AuditStatus.Commands;

public class CommandUpdateAuditStatusHandlerTests
{
    private readonly Mock<IAuditStatusRepository> _mock;
    private readonly IMapper _mapper;

    public CommandUpdateAuditStatusHandlerTests()
    {
        _mock = MockAuditStatusRepository.GetMockAuditStatusRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AuditStatusProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task UpdateAuditStatusTest()
    {
        var handler = new CommandUpdateAuditStatusHandler(_mapper, _mock.Object);

        var command = new CommandUpdateAuditStatus { Id = 1, Status = "Modified" };

        await handler.Handle(command, CancellationToken.None);;

        var updatedAuditStatus = (await _mock.Object.GetAsync())
            .FirstOrDefault(a => a.Id == command.Id);

        updatedAuditStatus.ShouldNotBeNull();

        updatedAuditStatus.Status.ShouldBe(command.Status);
    }
}
