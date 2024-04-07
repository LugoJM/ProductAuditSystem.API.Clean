namespace ProductAuditSystem.Application.Contracts.Infrastructure.JSONFileService;

public interface IJsonFileService
{
    string GetJsonFile();
    Task SaveJsonFile(object jsonFile);
}
