using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public interface IReadOnlyModuleData
    {
        int Id { get; }
        string Name { get; }
        (int X, int Y) Position { get; }
        (int finetune, int relativeNote) Finetune { get; }
        bool Solo { get; }
        bool Mute { get; }
        bool Bypass { get; }
        (int R, int G, int B) Color { get; }
        IReadOnlyCollection<(string name, int value)> Controllers { get; }
        IReadOnlyCollection<int> Inputs { get; }
        IReadOnlyCollection<int> Outputs { get; }
    }

    public class ModuleData : IReadOnlyModuleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public (int X, int Y) Position { get; set; }
        public (int finetune, int relativeNote) Finetune { get; set; }
        public bool Solo { get; set; }
        public bool Mute { get; set; }
        public bool Bypass { get; set; }
        public (int R, int G, int B) Color { get; set; }
        public ICollection<(string name, int value)> Controllers { get; set; }
        public ICollection<int> Inputs { get; set; }
        public ICollection<int> Outputs { get; set; }

        IReadOnlyCollection<(string name, int value)> IReadOnlyModuleData.Controllers => Controllers.AsReadonlyOrGetWrapper();
        IReadOnlyCollection<int> IReadOnlyModuleData.Inputs => Inputs.AsReadonlyOrGetWrapper();
        IReadOnlyCollection<int> IReadOnlyModuleData.Outputs => Outputs.AsReadonlyOrGetWrapper();

        public ModuleData()
        {
        }

        public static ModuleData DeepCopy(IReadOnlyModuleData data)
        {
            return new ModuleData
            {
                Id = data.Id,
                Name = data.Name,
                Position = data.Position,
                Finetune = data.Finetune,
                Solo = data.Solo,
                Mute = data.Mute,
                Bypass = data.Bypass,
                Color = data.Color,
                Controllers = data.Controllers.Select(c => (c.name, c.value)).ToArray(),
                Inputs = data.Inputs.Select(i => i).ToArray(),
                Outputs = data.Outputs.Select(o => o).ToArray()
            };
        }

        public static ModuleData ReadModuleData(ISunVoxLib lib, int slotId, int moduleId)
        {
            return lib.RunInLock(slotId, () => ReadModuleDataInternal(lib, slotId, moduleId));
        }

        public static ModuleData ReadModuleData(ModuleHandle module)
        {
            return module.Slot.RunInLock(() => ReadModuleDataInternal(module.Slot.Library, module.Slot.Id, module.Id));
        }

        internal static ModuleData ReadModuleDataInternal(ISunVoxLib lib, int slot, int moduleId)
        {
            var flags = lib.GetModuleFlags(slot, moduleId);
            var controllers = new (string name, int realValue)[lib.GetModuleControllerCount(slot, moduleId)];

            for (int i = 0; i < controllers.Length; i++)
            {
                var name = lib.GetModuleControllerName(slot, moduleId, i);
                var value = lib.GetModuleControllerValue(slot, moduleId, i, ValueScalingType.Real);
                controllers[i] = (name, value);
            }

            var moduleData = new ModuleData()
            {
                Bypass = flags.Bypass,
                Color = lib.GetModuleColor(slot, moduleId),
                Controllers = controllers,
                Finetune = lib.GetModuleFinetune(slot, moduleId),
                Id = moduleId,
                Inputs = lib.GetModuleInputs(slot, moduleId),
                Mute = flags.Mute,
                Name = lib.GetModuleName(slot, moduleId),
                Outputs = lib.GetModuleOutputs(slot, moduleId),
                Position = lib.GetModulePosition(slot, moduleId),
                Solo = flags.Solo
            };
            return moduleData;
        }
    }
}
