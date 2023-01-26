using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples.ExampleCode
{
    internal static class ObjectOrientedExample
    {
        public static void RunExample(ISunVoxLib lib)
        {
            using (var sv = new SunVox(lib))
            {
                DoWork(sv);
            }
        }

        private static void DoWork(SunVox sv)
        {
            Console.WriteLine("Loading a song");
            var slot = sv.Slots[0];
            slot.Open();
            slot.Load(@"ExampleProjects/the_lick.sunvox");
            Console.WriteLine($"Loaded song: {slot.GetSongName()}");

            ListPatterns(slot);
            ListModules(slot);
            PlaySong(slot);
            slot.Close();
        }

        private static void PlaySong(Slot slot)
        {
            int l = int.MinValue + 1;
            slot.RunInLock(() =>
            {
                slot.SetAutostop(true);
                slot.Rewind(0);
                slot.Play();
            });

            do
            {
                var nl = slot.GetCurrentLine();
                if (nl != l)
                {
                    l = nl;
                    Console.WriteLine($"Current line: {l}");
                }
                Thread.Sleep(20);
            } while (l != slot.GetSongLengthInLines() - 1 || slot.IsPlaying()); // this is weird and should be unnecessary
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
