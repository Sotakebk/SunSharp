using SunSharp;
using SunSharp.ThinWrapper;

namespace Examples;

internal class ThinWrapperListModulesAndPatterns : BaseExample
{
    protected override void RunTest(ISunVoxLib lib)
    {
        WriteLine("Initializing");
        lib.Init(sampleRate: -1);
        WriteLine("Loading the song");
        lib.OpenSlot(0);
        lib.Load(0, "the_lick.sunvox");

        ListModules(lib);
        ListPatterns(lib);

        lib.CloseSlot(0);
        lib.Deinit();
    }

    private void ListModules(ISunVoxLib lib)
    {
        WriteLine("Modules:");
        var count = lib.GetUpperModuleCount(0);
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < count; i++)
        {
            if (lib.GetModuleExists(0, i))
            {
                var name = lib.GetModuleName(0, i);
                dict.Add(i, name);
                WriteLine($"{i}. \"{name}\"");
            }
        }

        WriteLine("Connections:");
        for (int i = 0; i < count; i++)
        {
            if (lib.GetModuleExists(0, i))
            {
                foreach (var @out in lib.GetModuleOutputs(0, i))
                    WriteLine($"{i}. {dict[i]}->{@out}. {dict[@out]}");
            }
        }
    }

    private void ListPatterns(ISunVoxLib lib)
    {
        WriteLine("Patterns:");
        var count = lib.GetUpperPatternCount(0);
        for (int i = 0; i < count; i++)
        {
            if (lib.GetPatternExists(0, i))
            {
                var name = lib.GetPatternName(0, i);
                var position = lib.GetPatternPosition(0, i);
                var tracks = lib.GetPatternTracks(0, i);
                var lines = lib.GetPatternLines(0, i);
                var data = lib.GetPatternData(0, i);
                WriteLine($"{i}. \"{name}\" at position (x: {position.x}, y: {position.y}), length: ({tracks}x{lines})");

                WriteLine("Data:");
                WriteLine(string.Join(" ", Enumerable.Repeat("NNVVMMMMCCEEXXYY", tracks)));

                for (int l = 0; l < lines; l++)
                {
                    for (int t = 0; t < tracks; t++)
                    {
                        Write(data[l * tracks + t].ToString());
                        if (t < tracks - 1)
                            Write(" ");
                    }
                    Write(Environment.NewLine);
                }
            }
        }
    }
}
