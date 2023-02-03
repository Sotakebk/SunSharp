using CodeGeneration.Generators.SpecificGenerators;
using CodeGeneration.ReparsedData;
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
            // generate ProxyClass
            {
                var path = Path.GetDirectoryName(GetSourceFilePathName());
                path = Path.Join(path, "SunSharp", "LibraryLoading", "ProxyClass.Generated.cs");

                var generator = new ProxyClass_Generator();
                var changed = generator.Generate(path);
                if (changed)
                {
                    Console.WriteLine("ProxyClass was Generated, rebuild SunSharp and re-run to continue.");
                    return;
                }
            }

            // generate ModuleType
            {
                var path = Path.GetDirectoryName(GetSourceFilePathName()); // SunSharp parent path
                path = Path.Join(path, "SunSharp", "ObjectWrapper", "ModuleType.Generated.cs");

                var generator = new ModuleType_Generator();
                var changed = generator.Generate(path);
                if (changed)
                {
                    Console.WriteLine("ModuleType was generated, rebuild and re-run to regenerate SongData!");
                    return;
                }
            }

            SunSharp.Redistribution.LibraryLoader.LoadLibrary();
            var lib = SunSharp.Redistribution.LibraryLoader.GetLibrary();

            _sunVox = new SunVox(lib, 48000, OutputType.Float32, singleThreaded: true, noDebugOutput: false);
            var slot = _sunVox.Slots[0];
            slot.Open();
            slot.Load("all_modules.sunvox");

            // is ModuleTypes up to date?
            {
                var set = new HashSet<string>();
                foreach (var value in ModuleTypes.GetModuleTypes())
                    set.Add(value.internalName);

                foreach (var module in _sunVox.Slots[0].Synthesizer)
                {
                    var name = ModuleTypeHelper.InternalNameFromType(module.GetModuleType());
                    if (!set.Contains(name))
                    {
                        throw new Exception($"Type {name} is not known, add it to the ModuleTypes.cs first!");
                    }
                }
            }

            // regenerate SongData
            {
                var data = ModuleDataParser.ReparseModuleData(slot);

                var path = Path.Join(GetSourceFilePathName(), "ReparsedData", "Data.Regenerated.cs");

                var generator = new ModuleData_Generator(data);
                var changed = generator.Generate(path);
                if (changed)
                {
                    Console.WriteLine("ModuleData was regenerated, rebuild and re-run to regenerate SpecificModules!");
                    return;
                }
            }
            slot.Close();
            _sunVox.Dispose();

            // generate SpecificModules
            {
                var data = Data.GetData();

                var path = Path.GetDirectoryName(GetSourceFilePathName()); // SunSharp parent path
                path = Path.Join(path, "SunSharp", "ObjectWrapper", "Modules", "SpecificModules.Generated.cs");

                var generator = new SpecificModules_Generator(data);
                var changed = generator.Generate(path);
                if (changed)
                {
                    Console.WriteLine("SpecificModules was generated, rebuild SunSharp!");
                    return;
                }
            }

            Console.WriteLine("Nothing was changed, yay! :)");
        }
    }
}
