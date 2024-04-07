using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IFilesRepository : IGenericRepository<Files>
{
    Task AddFiles(List<Files> files);
    Task<Files> GetFile(int id);
    Task<List<Files>> GetFiles(int questionID);
    Task DeleteFile(Files file);
}
