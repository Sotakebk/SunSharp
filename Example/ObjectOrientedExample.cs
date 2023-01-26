using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples
{
    internal static class ObjectOrientedExample
    {
        public static void RunExample()
        {
            try
            {
                SunSharp.Redistribution.Redistribution.LoadLibrary();
                var lib = SunSharp.Redistribution.Redistribution.GetLibrary();
                InitAndDoWork(lib);
            }
            finally
            {
                SunSharp.Redistribution.Redistribution.UnloadLibrary();
            }
        }

        private static void InitAndDoWork(ISunVoxLib lib)
        {
            using (var sv = new SunVox(lib, 48000))
            {
                DoWork(sv);
            }
        }

        private static void DoWork(SunVox sv)
        {
            Console.WriteLine("Loading a song");
            var slot = sv.Slots[0];
            slot.Open();
            slot.Load(@"ExampleProjects/ths_lick.sunvox");
            Console.WriteLine($"Loaded song: {slot.GetSongName()}");
            ListPatterns(slot);
            ListModules(slot);
            PlaySong(slot);
            slot.Close();
        }

        private static void PlaySong(Slot slot)
        {
            slot.SetAutostop(true);
            slot.Rewind(0);
            var l = slot.GetCurrentLine();
            slot.PlayFromBeginning();
            while (slot.IsPlaying())
            {
                var nl = slot.GetCurrentLine();
                if (nl != l)
                {
                    l = nl;
                    Console.WriteLine($"Current line: {l}");
                }
                Thread.Sleep(10);
            }
        }

        private static void ListModules(Slot slot)
        {
            Console.WriteLine("Modules:");
            foreach (var module in slot.Synthesizer)
            {
                Console.WriteLine($"{module.Id}. {module.GetName()}");
                for (int i = 0; i < module.GetControllerCount(); i++)
                {
                    Console.WriteLine($"\t{i}. {module.GetControllerName(i)}, v:{module.GetControllerValue(i)}");
                }
            }
        }

        private static void ListPatterns(Slot slot)
        {
            Console.WriteLine("Patterns:");
            foreach (var pattern in slot.Timeline)
            {
                Console.WriteLine($"{pattern.Id}. {pattern.GetName()}");

                Console.WriteLine("Data:");
                Console.WriteLine(string.Join(" ", Enumerable.Repeat("NNVVMMMMCCEEXXYY", pattern.GetTrackCount())));
                var data = pattern.GetData2D();
                var length = pattern.GetLength();
                var tracks = pattern.GetTrackCount();
                for (int l = 0; l < length; l++)
                {
                    for (int t = 0; t < tracks; t++)
                    {
                        Console.Write(data[l, t].ToString());
                        if (t < tracks - 1)
                            Console.Write(" ");
                    }
                    Console.Write(Environment.NewLine);
                }
            }
        }
    }
}
