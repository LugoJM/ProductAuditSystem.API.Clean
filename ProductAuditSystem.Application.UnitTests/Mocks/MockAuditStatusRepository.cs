using Moq;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.UnitTests.Mocks;

public class MockAuditStatusRepository
{
    public static Mock<IAuditStatusRepository> GetMockAuditStatusRepository()
    {
        var auditStatuses = new List<AuditStatus>
        {
            new AuditStatus
            {
                Id = 1,
                Status = "In-Proccess"
            },
            new AuditStatus
            {
                Id = 2,
                Status = "Completed"
            },
            new AuditStatus
            {
                Id = 3,
                Status = "Failed"
            }
        };

        var mockRepo = new Mock<IAuditStatusRepository>();

        mockRepo.Setup(repo => repo.GetAsync())
            .ReturnsAsync(() => auditStatuses.ToList());

        mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int Id) => auditStatuses.FirstOrDefault(a => a.Id == Id));

        mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<AuditStatus>()))
            .Returns((AuditStatus auditStatus) =>
            {
                auditStatuses.Add(auditStatus);
                return Task.CompletedTask;
            });

        mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<AuditStatus>()))
            .Returns((AuditStatus auditStatus) =>
            {
                auditStatuses.Remove(auditStatus);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
