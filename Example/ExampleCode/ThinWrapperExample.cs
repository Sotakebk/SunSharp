using SunSharp;
using SunSharp.ThinWrapper;

namespace Examples.ExampleCode
{
    internal static class ThinWrapperExample
    {
        public static void RunExample(ISunVoxLib lib)
        {
            var version = lib.Init(sampleRate: 48000);
            Console.WriteLine(version.ToString());
            DoWork(lib);
            lib.Deinit();
        }

        private static void DoWork(ISunVoxLib lib)
        {
            Console.WriteLine("Loading a song");
            lib.OpenSlot(0);
            lib.LockSlot(0);
            lib.Load(0, "ExampleProjects/the_lick.sunvox");
            lib.UnlockSlot(0);

            Console.WriteLine($"Loaded song: {lib.GetSongName(0)}");

            ListModules(lib);
            ListPatterns(lib);
            PlaySong(lib);
            SendNotes(lib);
        }

        private static void ListModules(ISunVoxLib lib)
        {
            Console.WriteLine("Modules:");
            var count = lib.GetUpperModuleCount(0);
            var dict = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
            {
                if (lib.GetModuleExists(0, i))
                {
                    var name = lib.GetModuleName(0, i);
                    dict.Add(i, name);
                    Console.WriteLine($"{i}. \"{name}\"");
                }
            }

            Console.WriteLine("Connections:");
            for (int i = 0; i < count; i++)
            {
                if (lib.GetModuleExists(0, i))
                {
                    foreach (var @out in lib.GetModuleOutputs(0, i))
                    {
                        Console.WriteLine($"{i}. {dict[i]}->{@out}. {dict[@out]}");
                    }
                }
            }
        }

        private static void ListPatterns(ISunVoxLib lib)
        {
            Console.WriteLine("Patterns:");
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
                    Console.WriteLine($"{i}. \"{name}\" at position (x: {position.x}, y: {position.y}), length: ({tracks}x{lines})");

                    Console.WriteLine("Data:");
                    Console.WriteLine(string.Join(" ", Enumerable.Repeat("NNVVMMMMCCEEXXYY", tracks)));

                    for (int l = 0; l < lines; l++)
                    {
                        for (int t = 0; t < tracks; t++)
                        {
                            Console.Write(data[l * tracks + t].ToString());
                            if (t < tracks - 1)
                                Console.Write(" ");
                        }
                        Console.Write(Environment.NewLine);
                    }
                }
            }
        }

        private static void PlaySong(ISunVoxLib lib)
        {
            Console.WriteLine("Playing the song");
            lib.LockSlot(0);
            lib.SetAutostop(0, true);
            lib.Rewind(0, 0);
            lib.Play(0);
            lib.UnlockSlot(0);

            int l = 0;
            while (l != lib.GetSongLengthLines(0) - 1 || !lib.EndOfSong(0))
            {
                var nl = lib.GetCurrentLine(0);
                if (nl != l)
                {
                    Console.WriteLine($"{DateTime.Now:HH:mm:ss:fffffff} G {!lib.EndOfSong(0)}");
                    l = nl;
                    Console.WriteLine($"Current line: {l}");
                }
                Thread.Sleep(10);
            }
        }

        private static void SendNotes(ISunVoxLib lib)
        {
            var tps = lib.GetTicksPerSecond();
            Console.WriteLine("Sending a few notes.");
            var tpb = (int)(tps * 60f / 80f);
            var data = new (Note note, int time)[] // the lick, lol
            {
                (new Note(NoteName.D, 3), tpb/4),
                (new Note(NoteName.E, 3), tpb/4),
                (new Note(NoteName.F, 3), tpb/4),
                (new Note(NoteName.G, 3), tpb/4),
                (new Note(NoteName.E, 3), tpb * 2/4),
                (new Note(NoteName.C, 3), tpb/4),
                (new Note(NoteName.D, 3), tpb/4),
                (Note.Off, 0)
            };
            lib.LockSlot(0);
            int accumulator = 0;
            uint current = lib.GetTicks() + tps / 2;
            foreach (var pair in data)
            {
                uint _current = lib.GetTicks();
                lib.SetSendEventTimestamp(0, false, (int)(accumulator + current));
                lib.SendEvent(0, 0, new Event(pair.note, 0x80, 2));
                accumulator += pair.time;
            }
            lib.SetSendEventTimestamp(0, true);
            lib.UnlockSlot(0);
            var wait = (accumulator / (float)tps) + 1;
            Console.WriteLine($"Waiting {wait} seconds...");
            Thread.Sleep((int)(wait * 1000));
        }
    }
}
