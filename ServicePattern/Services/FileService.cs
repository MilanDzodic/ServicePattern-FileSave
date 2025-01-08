using System.Diagnostics;
using System.Text.Json;
using ServicePattern.Models;

namespace ServicePattern.Services;

public class FileService
{
  private readonly string _directoryPath;
  private readonly string _filePath;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public FileService(string directoryPath = "Data", string filePath = "List.json")
  {
    _directoryPath = directoryPath;
    _filePath = Path.Combine(_directoryPath, filePath);
    _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
  }

  public void SaveListToFile(List<UserEntity> list)
  {
    try
    {
      if (!Directory.Exists(_directoryPath))
      {
        Directory.CreateDirectory(_directoryPath);
      }

      var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
      File.WriteAllText(_filePath, json);
    }

    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
    }
  }

  public IEnumerable<UserEntity> LoadListFromFile()
  {
    try
    {
      if (!File.Exists(_filePath))
      {
        return [];
      }

      var json = File.ReadAllText(_filePath);
      var list = JsonSerializer.Deserialize<List<UserEntity>>(json, _jsonSerializerOptions);
      return list ?? [];
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return [];
    }
  }
}
