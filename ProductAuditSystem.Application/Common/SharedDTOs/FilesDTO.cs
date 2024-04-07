namespace ProductAuditSystem.Application.Common.SharedDTOs;

public class FilesDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MIME_Type { get; set; } = string.Empty;
    public byte[]? Content { get; set; }
}
