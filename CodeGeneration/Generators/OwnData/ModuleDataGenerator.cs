using System.Text.Json;
using System.Text.RegularExpressions;
using CodeGeneration.Logic;
using SunSharp;
using SunSharp.Redistribution;

namespace CodeGeneration.Generators.OwnData;

public sealed partial class ModuleDataGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new ModuleDataGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("CodeGeneration/Logic/ModuleData.g.json");

    public override int Priority => 10;

    public override string Name => "ModuleData.g.json";

    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerOptions.Default)
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        WriteIndented = true,
        RespectNullableAnnotations = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    };

    protected override string GenerateBody()
    {
        var currentData = ModuleDataLoader.LoadFromFile(FilePath);
        var readData = ReadModuleDataFromSunVox();

        var mergedData = MergeData(readData, currentData);

        var result = JsonSerializer.SerializeToNode(mergedData, _jsonOptions)
            ?? throw new Exception();

        result["$schema"] = "./schema.g.json";

        return result.ToJsonString(_jsonOptions);
    }

    private static KnownModuleData ReadModuleDataFromSunVox()
    {
        bool loaded = false;
        try
        {
            LibraryLoader.Load();
            loaded = true;

            var instance = LibraryLoader.GetLibraryInstance();
            using var sunVox = new SunVox(instance, 48000, OutputType.Float32, singleThreaded: true, noDebugOutput: false);
            var slot = sunVox.Slots[0];

            slot.Open();
            foreach (var module in KnownModuleTypes.ModuleTypes.Where(m => m.Index > 0))
            {
                instance.CreateModule(0, module.InternalName, module.InternalName);
            }
            var modules = CreateModuleDescriptions(slot);

            slot.Close();
            Console.WriteLine("Logs: " + sunVox.GetLog(0xFFFF));

            return new KnownModuleData()
            {
                Modules = modules
            };
        }
        finally
        {
            if (loaded)
            {
                LibraryLoader.Unload();
            }
        }
    }

    private static Dictionary<string, ModuleDescription> CreateModuleDescriptions(Slot slot)
    {
        var dict = new Dictionary<string, ModuleDescription>();
        foreach (var module in slot.Synthesizer)
        {
            var (name, description) = CreateModuleDescription(module);

            dict.Add(name, description);
        }
        return dict;
    }

    private static (string name, ModuleDescription description) CreateModuleDescription(SynthModuleHandle module)
    {
        var internalTypeName = module.Slot.Library.GetModuleType(module.Slot.Id, module.Id)
            ?? throw new Exception($"Module {module} type name is null.");
        var friendlyName = KnownModuleTypes.ModuleTypes.First(m => m.InternalName == internalTypeName).FriendlyName;

        var controllers = CreateControllersDescriptions(module);
        var curves = CreateCurvesDescriptions(module);

        return (internalTypeName, new ModuleDescription()
        {
            Controllers = controllers,
            Curves = curves,
        });
    }

    private static Dictionary<int, CurveDescription> CreateCurvesDescriptions(SynthModuleHandle module)
    {
        var curves = new Dictionary<int, CurveDescription>();
        var buffer = new float[65536];
        for (var i = 0; i < 256; i++)
        {
            try
            {
                var size = module.ReadCurve(i, buffer);
                //var readSize = module.WriteCurve(i, buffer);
                if (size == 0)
                {
                    Console.WriteLine($"Curve {i} of module {module} has size 0, stopping curve read.");
                    break;
                }
                var min = buffer.Take(size).Min();
                var max = buffer.Take(size).Max();
                curves.Add(i, new CurveDescription()
                {
                    FriendlyName = $"Curve{i}",
                    Size = size,
                    MinValue = min,
                    MaxValue = max,
                    Description = null
                });
            }
            catch (SunVoxException exception)
            {
                Console.WriteLine($"No more curves found for module {module} after {i} curves. ({exception.Message})");
                break;
            }
        }

        return curves;
    }

    private static Dictionary<int, ControllerDescription> CreateControllersDescriptions(SynthModuleHandle module)
    {
        var controllerDescriptions = new Dictionary<int, ControllerDescription>();
        var controllerCount = module.GetControllerCount();
        for (var i = 0; i < controllerCount; i++)
        {
            var controllerDescription = CreateControllerDescription(module, i);
            if (controllerDescription != null)
            {
                controllerDescriptions.Add(i, controllerDescription);
            }
        }

        return controllerDescriptions;
    }

    private static ControllerDescription? CreateControllerDescription(SynthModuleHandle module, int id)
    {
        var internalName = module.GetControllerName(id);
        if (internalName == null)
        {
            return null;
        }

        var controllerType = module.GetControllerType(id);

        var minValue = module.GetControllerMinValue(id, ValueScalingMode.Real);
        var maxValue = module.GetControllerMaxValue(id, ValueScalingMode.Real);
        var maxDisplayedValue = module.GetControllerMaxValue(id, ValueScalingMode.Displayed);
        var minDisplayedValue = module.GetControllerMinValue(id, ValueScalingMode.Displayed);
        var offset = module.GetControllerOffset(id);

        return new ControllerDescription()
        {
            InternalName = internalName,
            FriendlyName = MakeControllerNameFriendly(internalName),
            Description = null,
            EnumName = (controllerType == ControllerType.Selector) ? "CHANGEME" : null,
            SelectorIsNotEnum = false,
            MaxDisplayedValue = maxDisplayedValue,
            MaxValue = maxValue,
            MinDisplayedValue = minDisplayedValue,
            MinValue = minValue,
            ControllerType = controllerType,
            Offset = offset,
        };
    }

    private static string MakeControllerNameFriendly(string name)
    {
        // remove all non-alphanumeric characters and capitalize each word then concatenate them
        // together, resulting in PascalCase if the name starts with a number, move the number to
        // the end instead

        return ControllerNameRegex().Matches(name)
            .Select((w, i) => new { value = w.Value, startsWithDigit = char.IsDigit(w.Value[0]), index = i })
            .OrderBy(w => w.startsWithDigit ? 1 : 0)
            .ThenBy(w => w.index)
            .Select(w => char.ToUpperInvariant(w.value[0]) + w.value[1..].ToLowerInvariant()) // PascalCase
            .Aggregate("", (a, b) => a + b);
    }

    private static KnownModuleData MergeData(KnownModuleData sunVoxData, KnownModuleData? currentData)
    {
        if (currentData == null)
        {
            return sunVoxData;
        }

        ModuleDescription MergeModuleDescription(string name, ModuleDescription sunVoxDescription)
        {
            currentData.Modules.TryGetValue(name, out var currentDescription);
            if (currentDescription == null)
            {
                Console.WriteLine($"New module found: {name}");
                return sunVoxDescription;
            }

            return MergeModuleData(sunVoxDescription, currentDescription);
        }

        var newDict = new Dictionary<string, ModuleDescription>();
        foreach (var (key, value) in sunVoxData.Modules)
        {
            newDict.Add(key, MergeModuleDescription(key, value));
        }

        return new KnownModuleData()
        {
            Modules = newDict
        };
    }

    private static ModuleDescription MergeModuleData(ModuleDescription sunVoxData, ModuleDescription currentData)
    {
        var mergedControllers = new Dictionary<int, ControllerDescription>();
        foreach (var (index, value) in sunVoxData.Controllers)
        {
            currentData.Controllers.TryGetValue(index, out var match);
            if (match == null)
            {
                Console.WriteLine($"New controller found: {index}.{value.InternalName}");
                mergedControllers.Add(index, value);
            }
            else
            {
                mergedControllers.Add(index, MergeControllerData(value, match));
            }
        }

        var mergedCurves = new Dictionary<int, CurveDescription>();
        foreach (var (index, value) in sunVoxData.Curves)
        {
            currentData.Curves.TryGetValue(index, out var match);
            if (match == null)
            {
                Console.WriteLine($"New curve found: {index}.{value.FriendlyName}");
                mergedCurves.Add(index, value);
                continue;
            }
            else
            {
                if (match.MinValue == null || match.MaxValue == null)
                {
                    Console.WriteLine($"Curve {index}.{match.FriendlyName} (l:{value.Size}) is missing min/max value in current data, filling in from SunVox data. New values: {value.MinValue}, {value.MaxValue}");
                }
                else if (match.MinValue != value.MinValue || match.MaxValue != value.MaxValue)
                {
                    Console.WriteLine($"Curve {index}.{match.FriendlyName} (l:{value.Size}) has different min/max values in current data vs SunVox data. Current: {match.MinValue}, {match.MaxValue}. SunVox: {value.MinValue}, {value.MaxValue}. Keeping current values.");
                }
                mergedCurves.Add(index, new CurveDescription()
                {
                    Description = match.Description,
                    FriendlyName = match.FriendlyName,
                    MaxValue = match.MaxValue ?? value.MaxValue,
                    MinValue = match.MinValue ?? value.MinValue,
                    Size = match.Size
                });
            }
        }

        return new ModuleDescription()
        {
            Controllers = mergedControllers,
            Curves = mergedCurves
        };
    }

    private static ControllerDescription MergeControllerData(ControllerDescription sunVoxController, ControllerDescription matching)
    {
        var selectorIsNotEnum = (sunVoxController.ControllerType == ControllerType.Normal)
            ? null
            : matching.SelectorIsNotEnum;

        var enumName = selectorIsNotEnum != true
            ? matching.EnumName ?? sunVoxController.EnumName
            : null;

        return new ControllerDescription()
        {
            Description = matching.Description,
            FriendlyName = matching.FriendlyName,
            InternalName = sunVoxController.InternalName,
            MinValue = sunVoxController.MinValue,
            MaxValue = sunVoxController.MaxValue,
            MinDisplayedValue = sunVoxController.MinDisplayedValue,
            MaxDisplayedValue = sunVoxController.MaxDisplayedValue,
            SelectorIsNotEnum = selectorIsNotEnum,
            EnumName = enumName,
            ControllerType = sunVoxController.ControllerType,
            Offset = sunVoxController.Offset,
        };
    }

    [GeneratedRegex(@"[A-Za-z]+|\d+")]
    private static partial Regex ControllerNameRegex();
}
