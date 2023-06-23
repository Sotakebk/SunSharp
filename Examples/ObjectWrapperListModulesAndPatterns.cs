using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples;

internal class ObjectWrapperListModulesAndPatterns : BaseExample
{
    protected override void RunTest(ISunVoxLib lib)
    {
        WriteLine("Initializing");
        using (var sv = new SunVox(lib))
        {
            WriteLine("Loading the song");
            var slot = sv.Slots[0];
            slot.Open();
            slot.Load("the_lick.sunvox");
            WriteLine($"Loaded song: {slot.GetSongName()}");

            ListModules(slot);
            ListPatterns(slot);

            slot.Close();
        }
    }

    private void ListModules(Slot slot)
    {
        WriteLine("Modules:");
        foreach (var module in slot.Synthesizer)
        {
            WriteLine($"{module.Id}. {module.GetName()}");
            for (int i = 0; i < module.GetControllerCount(); i++)
                WriteLine($"\t{i}. {module.GetControllerName(i)}, v:{module.GetControllerValue(i)}");
        }
    }

    private void ListPatterns(Slot slot)
    {
        WriteLine("Patterns:");
        foreach (var pattern in slot.Timeline)
        {
            WriteLine($"{pattern.Id}. {pattern.GetName()}");

            WriteLine("Data:");
            WriteLine(string.Join(" ", Enumerable.Repeat("NNVVMMMMCCEEXXYY", pattern.GetTrackCount())));
            var data = pattern.GetData2D();
            var length = pattern.GetLength();
            var tracks = pattern.GetTrackCount();
            for (int l = 0; l < length; l++)
            {
                for (int t = 0; t < tracks; t++)
                {
                    Write(data[l, t].ToString());
                    if (t < tracks - 1)
                        Write(" ");
                }

                Write(Environment.NewLine);
            }
        }
    }
}
