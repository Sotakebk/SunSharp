using SunSharp.ObjectWrapper;
using System.Text.RegularExpressions;

namespace CodeGeneration
{
    internal class ModuleDataParser
    {
        internal static Data ReparseModuleData(Slot slot)
        {
            var currentData = Data.GetData();

            var newData = new Data();
            newData.Modules = new List<ModuleDescription>();
            newData.Enums = currentData.Enums;

            foreach (var module in slot.Synthesizer)
            {
                var internalName = module.GetName();
                var existingDescription = currentData.Modules.FirstOrDefault(d => d.InternalName == internalName);
                newData.Modules.Add(CreateModuleDescription(existingDescription, module));
            }

            foreach (var module in newData.Modules)
            {
                foreach (var controller in module.Controllers)
                {
                    if (controller.EnumTypeName == null)
                        continue;

                    var @enum = newData.Enums.FirstOrDefault(e => e.Name == controller.EnumTypeName);
                    if (@enum == null)
                    {
                        Console.WriteLine($"Missing enum type {controller.EnumTypeName} of controller {controller.Id} on module {module.Name}");
                        continue;
                    }

                    var min = @enum.Values.Min(v => v.value);
                    var max = @enum.Values.Max(v => v.value);
                    if (min != controller.MinValue || max != controller.MaxValue)
                    {
                        Console.WriteLine($"Enum {controller.EnumTypeName} of module {module.Name} doesn't fit value range of controller {controller.OriginalName} (is: {min} to {max}, but expected ({controller.MinValue} to {controller.MaxValue})");
                    }
                }
            }

            return newData;
        }

        internal static ModuleDescription CreateModuleDescription(ModuleDescription original, Module module)
        {
            var moduleInternalName = module.GetName();
            var name = Data.GetModuleTypeDictionary()[moduleInternalName];
            var description = original?.Description ?? string.Empty;
            var controllerDescriptions = new List<ControllerDescription>();
            var curveDescriptions = original?.Curves ?? new List<CurveDescription>();

            for (int i = 0; i < module.GetControllerCount(); i++)
            {
                var origController = original?.Controllers?.FirstOrDefault(c => c.Id == i);
                controllerDescriptions.Add(CreateControllerDescription(origController, module, i));
            }

            return new ModuleDescription(name, moduleInternalName, description, controllerDescriptions, curveDescriptions);
        }

        internal static ControllerDescription CreateControllerDescription(ControllerDescription original, Module module, int i)
        {
            var originalName = module.GetControllerName(i);
            var name = original?.Name ?? SanitizeControllerName(originalName);
            var description = original?.Description ?? string.Empty;

            module.SetControllerValue(i, 0);
            Program.GuaranteeEventProcessing();
            var min = module.GetControllerValue(i, false);

            module.SetControllerValue(i, 0x8000);
            Program.GuaranteeEventProcessing();
            var max = module.GetControllerValue(i, false);
            if (min == max)
            {
                Console.WriteLine($"min==max ({min}) on {i}.{name}@{module.GetName()}, ignoring if possible.");
                min = original?.MinValue ?? min;
                max = original?.MaxValue ?? max + 1;
            }

            if (original != null)
            {
                if (original.MinValue != min)
                    Console.WriteLine($"MinValue changed on {i}.{name}@{module.GetName()}");
                if (original.MaxValue != max)
                    Console.WriteLine($"MaxValue changed on {i}.{name}@{module.GetName()}");
                if (original.OriginalName != originalName)
                    Console.WriteLine($"Originalname changed on {i}.{name}@{module.GetName()}");
            }

            return new ControllerDescription(i, name, originalName, description, min, max, original?.EnumTypeName);
        }

        internal static string SanitizeControllerName(string name)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 ]");
            var _sanitized = rgx.Replace(name, " ");
            var words = _sanitized.Split(' ');
            var capitalizedWords = words.Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => string.Concat(char.ToUpper(s[0]), s[1..]));
            return string.Join(string.Empty, capitalizedWords);
        }
    }
}
