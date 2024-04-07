using ProductAuditSystem.Application.Contracts.Infrastructure.JSONFileService;

namespace ProductAuditSystem.Infrastructure.JsonFileService;

internal class JSONFileService : IJsonFileService
{
    private readonly string _jsonFilePath;

    public JSONFileService()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string solutionDirectory = Directory.GetParent(currentDirectory).FullName;

        _jsonFilePath = Path.Combine(solutionDirectory, "ProductAuditSystem.Infrastructure", "Data", "templateInformation.json");
    }
    public string GetJsonFile()
    {
        string jsonContent = File.ReadAllText(_jsonFilePath);
        return jsonContent;
    }

    public async Task SaveJsonFile(object jsonFile)
    {
        var valor = Convert.ToString(jsonFile);
        await File.WriteAllTextAsync(_jsonFilePath, valor);
    }
}