using System.Text.Json;
using System.Text.Json.Schema;
using CodeGeneration.Logic;

namespace CodeGeneration.Generators.OwnData;

public sealed class ModuleDataSchemaGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new ModuleDataSchemaGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("CodeGeneration/Logic/ModuleData.g.schema.json");

    public override int Priority => 10;

    public override string Name => "ModuleData.g.schema.json";

    protected override string GenerateBody()
    {
        var options = new JsonSerializerOptions(JsonSerializerOptions.Default)
        {
            WriteIndented = true
        };
        var schema = options.GetJsonSchemaAsNode(typeof(KnownModuleData));

        return schema.ToJsonString(options);
    }
}
