using CodeGeneration.ReparsedData;
using SunSharp;
using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System.Text.RegularExpressions;

namespace CodeGeneration
{
    internal class ModuleDataParser
    {
        internal static Data ReparseModuleData(Slot slot)
        {
            var oldData = Data.GetData();

            var newData = new Data();
            newData.Modules = new List<ModuleDesc>();
            newData.Enums = oldData.Enums;

            RecreateModuleDescriptions(oldData, newData, slot);

            return newData;
        }

        internal static void RecreateModuleDescriptions(Data oldData, Data newData, Slot slot)
        {
            foreach (var module in slot.Synthesizer)
            {
                var internalName = module.GetName();
                var existingDescription = oldData.Modules.FirstOrDefault(d => d.InternalName == internalName);
                var newDescription = CreateModuleDescription(newData, existingDescription, module);
                newData.Modules.Add(newDescription);
            }
        }

        internal static ModuleDesc CreateModuleDescription(Data newData, ModuleDesc original, SunSharp.ObjectWrapper.ModuleHandle module)
        {
            var internalName = module.Slot.Library.GetModuleName(module.Slot.Id, module.Id);
            var friendlyName = ModuleTypes.GetFriendlyName(internalName);
            var description = original?.Description ?? string.Empty;
            var controllerDescriptions = new List<CtlDesc>();
            var curveDescriptions = original?.Curves ?? new List<CurveDesc>();

            for (int i = 0; i < module.GetControllerCount(); i++)
            {
                var originalControllerDescription = original?.Controllers?.FirstOrDefault(c => c.Id == i);
                var controllerDescription = CreateControllerDescription(newData, originalControllerDescription, module, i);
                controllerDescriptions.Add(controllerDescription);
            }

            return new ModuleDesc(friendlyName, internalName, description, controllerDescriptions, curveDescriptions, original?.AdditionalCodeDescription);
        }

        internal static CtlDesc CreateControllerDescription(Data newData, CtlDesc original, SunSharp.ObjectWrapper.ModuleHandle module, int i)
        {
            var originalName = module.GetControllerName(i);
            var friendlyName = original?.FriendlyName ?? SanitizeControllerName(originalName);
            var description = original?.Description ?? string.Empty;

            var minValue = module.GetControllerMinValue(i, ValueScalingType.Displayed);
            var maxValue = module.GetControllerMaxValue(i, ValueScalingType.Displayed);

            if (original != null)
            {
                if (original.MinValue != minValue)
                    Console.WriteLine($"MinValue changed on {i}.{friendlyName}@{module.GetName()} (was: {original.MinValue}, is: {minValue})");
                if (original.MaxValue != maxValue)
                    Console.WriteLine($"MaxValue changed on {i}.{friendlyName}@{module.GetName()} (was: {original.MaxValue}, is: {maxValue})");
                if (original.InternalName != originalName)
                    Console.WriteLine($"InternalName changed on {i}.{friendlyName}@{module.GetName()}  (was: {original.FriendlyName}, is: {friendlyName})");
            }

            var originalIsEnum = module.GetControllerType(i);
            if (originalIsEnum == ControllerType.Enum)
            {
                if (original == null)
                {
                    Console.WriteLine($"Newly found controller {i}.{friendlyName}@{module.GetName()} is of type Enum");
                }
                else if (original.IgnoreInternalEnum == false && !string.IsNullOrWhiteSpace(original.EnumTypeName))
                {
                    var @enum = newData.Enums.FirstOrDefault(e => e.Name == original.EnumTypeName);
                    if (@enum == null)
                    {
                        Console.WriteLine($"Enum {original.EnumTypeName} of controller {i}.{friendlyName}@{module.GetName()} was not found!");
                    }
                    else
                    {
                        var min = @enum.Values.Min(v => v.value);
                        var max = @enum.Values.Max(v => v.value);
                        if (min != original.MinValue || max != original.MaxValue)
                        {
                            Console.WriteLine($"Enum {@enum.Name} doesn't fit value range of controller {i}.{friendlyName}@{module.GetName()} (is: {min} to {max}, but expected ({minValue} to {maxValue})");
                        }
                    }
                }
                else if (original.IgnoreInternalEnum == false)
                {
                    Console.WriteLine($"Missing enum type or ignore on controller {i}.{friendlyName}@{module.GetName()}");
                }
            }
            else
            {
                if (original != null)
                {
                    if (!string.IsNullOrWhiteSpace(original.EnumTypeName))
                    {
                        Console.WriteLine($"Controller {i}.{friendlyName}@{module.GetName()} is of type Real, but enum name is assigned");
                    }
                    if (original.IgnoreInternalEnum)
                    {
                        Console.WriteLine($"Controller {i}.{friendlyName}@{module.GetName()} has unnecessary ignore of missing Enum, since controller is of type Real");
                    }
                }
            }

            return new CtlDesc(i, friendlyName, originalName, description, minValue, maxValue, original?.IgnoreInternalEnum ?? false, original?.EnumTypeName);
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
