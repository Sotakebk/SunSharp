using SunSharp;
using SunSharp.ThinWrapper;

namespace ManualJobs.Tests
{
    public class ThinWrapperTest : BaseManualTest
    {
        protected override void RunTest(ISunVoxLib lib)
        {
            var version = lib.Init(sampleRate: 48000);
            WriteLine(version.ToString());
            DoWork(lib);
            lib.Deinit();
        }

        private void DoWork(ISunVoxLib lib)
        {
            WriteLine("Loading a song");
            lib.OpenSlot(0);
            lib.LockSlot(0);
            lib.Load(0, Path.Join(Program.SunVoxProjectFolder, "the_lick.sunvox"));
            lib.UnlockSlot(0);

            WriteLine($"Loaded song: {lib.GetSongName(0)}");

            ListModules(lib);
            ListPatterns(lib);
            PlaySong(lib);
            SendNotes(lib);
        }

        private void ListModules(ISunVoxLib lib)
        {
            WriteLine("Modules:");
            var count = lib.GetUpperModuleCount(0);
            var dict = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
                if (lib.GetModuleExists(0, i))
                {
                    var name = lib.GetModuleName(0, i);
                    dict.Add(i, name);
                    WriteLine($"{i}. \"{name}\"");
                }

            WriteLine("Connections:");
            for (int i = 0; i < count; i++)
                if (lib.GetModuleExists(0, i))
                    foreach (var @out in lib.GetModuleOutputs(0, i))
                        WriteLine($"{i}. {dict[i]}->{@out}. {dict[@out]}");
        }

        private void ListPatterns(ISunVoxLib lib)
        {
            WriteLine("Patterns:");
            var count = lib.GetUpperPatternCount(0);
            for (int i = 0; i < count; i++)
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

        private void PlaySong(ISunVoxLib lib)
        {
            WriteLine("Playing the song");
            lib.LockSlot(0);
            lib.SetAutostop(0, true);
            lib.Rewind(0, 0);
            lib.Play(0);
            lib.UnlockSlot(0);

            int l = 0;
            while (l != lib.GetSongLengthInLines(0) - 1 || lib.IsPlaying(0))
            {
                var nl = lib.GetCurrentLine(0);
                if (nl != l)
                {
                    l = nl;
                    WriteLine($"Current line: {l}");
                }
                Thread.Sleep(10);
            }
        }

        private void SendNotes(ISunVoxLib lib)
        {
            var tps = lib.GetTicksPerSecond();
            WriteLine("Sending a few notes.");
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
                lib.SendEvent(0, 0, new PatternEvent(pair.note, 0x80, 2));
                accumulator += pair.time;
            }
            lib.SetSendEventTimestamp(0, true);
            lib.UnlockSlot(0);
            var wait = accumulator / (float)tps + 1;
            WriteLine($"Waiting {wait} seconds...");
            Thread.Sleep((int)(wait * 1000));
        }
    }
}
