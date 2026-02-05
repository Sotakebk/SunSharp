using System.Text.Json;

namespace CodeGeneration.Logic;

public static class ModuleDataLoader
{
    public static KnownModuleData? LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"File not found: {path}");
            return null;
        }

        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read file: {ex.Message}");
            return null;
        }

        using var document = System.Text.Json.JsonDocument.Parse(json);

        if (!document.RootElement.TryGetProperty("Modules", out var modulesDictionary))
        {
            Console.WriteLine("No 'Modules' property found in JSON");
            return null;
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var modules = new Dictionary<string, ModuleDescription>();

        foreach (var moduleElement in modulesDictionary.EnumerateObject())
        {
            var internalName = moduleElement.Name;
            try
            {
                var controllers = LoadDictionary<ControllerDescription>(
                    moduleElement.Value, "Controllers", internalName, options);

                var curves = LoadDictionary<CurveDescription>(
                    moduleElement.Value, "Curves", internalName, options);

                modules[internalName] = new ModuleDescription
                {
                    Controllers = controllers,
                    Curves = curves
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to deserialize module '{internalName}': {ex.Message}");
            }
        }

        return new KnownModuleData
        {
            Modules = modules,
        };
    }

    private static Dictionary<int, T> LoadDictionary<T>(
        JsonElement moduleElement,
        string propertyName,
        string moduleName,
        JsonSerializerOptions options)
    {
        var result = new Dictionary<int, T>();

        if (!moduleElement.TryGetProperty(propertyName, out var objectElement))
        {
            return result;
        }

        foreach (var element in objectElement.EnumerateObject())
        {
            try
            {
                if (!int.TryParse(element.Name, out int id))
                {
                    Console.WriteLine($"{propertyName} in module '{moduleName}' has invalid Id key '{element.Name}', skipping");
                    continue;
                }

                var item = System.Text.Json.JsonSerializer.Deserialize<T>(
                    element.Value.GetRawText(), options);

                if (item != null)
                {
                    result[id] = item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to deserialize {propertyName.TrimEnd('s').ToLower()} '{element.Name}' in module '{moduleName}': {ex.Message}");
            }
        }

        return result;
    }
}
