using AutoMapper;
using Moq;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandDeleteAuditStatus;
using ProductAuditSystem.Application.MappingProfiles;
using ProductAuditSystem.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductAuditSystem.Application.UnitTests.Features.AuditStatus.Commands;

public class CommandDeleteAuditStatusHandlerTests
{
    private readonly Mock<IAuditStatusRepository> _mock;

    public CommandDeleteAuditStatusHandlerTests()
    {
        _mock = MockAuditStatusRepository.GetMockAuditStatusRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AuditStatusProfile>();
        });

    }


    [Fact]
    public async Task DeleteAuditStatusTests()
    {
        var handler = new CommandDeleteAuditStatusHandler(_mock.Object);

        await handler.Handle(new CommandDeleteAuditStatus(1), CancellationToken.None);

        var auditStatuses = await _mock.Object.GetAsync();

        auditStatuses.Count.ShouldBe(2);

    }
}
