
namespace ProductAuditSystem.Application.Responses;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = new();
}
