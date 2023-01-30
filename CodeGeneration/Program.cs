using SunSharp.ObjectWrapper;
using System.Runtime.CompilerServices;

namespace CodeGeneration
{
    internal static class Program
    {
        internal static SunVox _sunVox;

        internal static string GetSourceFilePathName([CallerFilePath] string callerFilePath = null) => Path.GetDirectoryName(callerFilePath) ?? "";

        private static float[] buffer = new float[32];

        internal static void GuaranteeEventProcessing()
        {
            // TODO FIXME UGLY
            _sunVox.AudioCallback(buffer, 0, _sunVox.GetTicks());
        }

        internal static void Main()
        {
            SunSharp.Redistribution.Redistribution.LoadLibrary();
            var lib = SunSharp.Redistribution.Redistribution.GetLibrary();

            _sunVox = new SunVox(lib, 48000, OutputType.Float32, singleThreaded: true, noDebugOutput: false);
            var slot = _sunVox.Slots[0];
            slot.Open();
            slot.Load("all_modules.sunvox");

            CheckModuleTypeEnum();
            var data = ModuleDataParser.ReparseModuleData(slot);

            var generator = new ModuleData_Generator(data);
            var moduleDataPath = Path.Join(GetSourceFilePathName(), "ModuleData_Regenerated.cs");
            if (generator.Generate(moduleDataPath))
            {
                Console.WriteLine("ModuleData was regenerated, rebuild and re-run to regenerate SpecificModules!");
                return;
            }

            var smgenerator = new SpecificModules_Generator(data);
            var path = Path.GetDirectoryName(GetSourceFilePathName()); // SunSharp parent path
            path = Path.Join(path, "SunSharp", "ObjectWrapper", "Modules", "SpecificModules_Regenerated.cs");
            if (smgenerator.Generate(path))
            {
                Console.WriteLine("SpecificModules was regenerated, rebuild SunSharp!");
            }
        }

        internal static void CheckModuleTypeEnum()
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var value in Data.GetModuleTypeDictionary())
                dictionary.Add(value.Key, value.Value);

            foreach (var module in _sunVox.Slots[0].Synthesizer)
            {
                var name = module.GetName();
                if (!dictionary.ContainsKey(name))
                    throw new Exception($"Type {name} is not known, add it to the enums first!");
            }
        }
    }
}
