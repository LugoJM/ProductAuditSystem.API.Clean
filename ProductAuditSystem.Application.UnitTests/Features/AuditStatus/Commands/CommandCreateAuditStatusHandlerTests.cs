using AutoMapper;
using Moq;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;
using ProductAuditSystem.Application.MappingProfiles;
using ProductAuditSystem.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductAuditSystem.Application.UnitTests.Features.AuditStatus.Commands;

public class CommandCreateAuditStatusHandlerTests
{
    private readonly Mock<IAuditStatusRepository> _mock;
    private readonly IMapper _mapper;
    public CommandCreateAuditStatusHandlerTests()
    {
        _mock = MockAuditStatusRepository.GetMockAuditStatusRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AuditStatusProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateAuditStatusTests()
    {
        var handler = new CommandCreateAuditStatusHandler(_mapper, _mock.Object);

        await handler.Handle(new CommandCreateAuditStatus { Status = "Test Status" }, CancellationToken.None);

        var auditStatus = await _mock.Object.GetAsync();

        auditStatus.Count.ShouldBe(4);
    }
}
