using SunSharp;
using SunSharp.ObjectWrapper;

namespace ManualJobs.Tests
{
    public class ObjectOrientedTest : BaseManualTest
    {
        protected override void RunTest(ISunVoxLib lib)
        {
            using (var sv = new SunVox(lib))
                DoWork(sv);
        }

        private void DoWork(SunVox sv)
        {
            WriteLine("Loading a song");
            var slot = sv.Slots[0];
            slot.Open();
            slot.Load(Path.Join(Program.SunVoxProjectFolder, "the_lick.sunvox"));
            WriteLine($"Loaded song: {slot.GetSongName()}");

            ListPatterns(slot);
            ListModules(slot);
            PlaySong(slot);
            slot.Close();
        }

        private void PlaySong(Slot slot)
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
                    WriteLine($"Current line: {l}");
                }
                Thread.Sleep(20);
            } while (l != slot.GetSongLengthInLines() - 1 || slot.IsPlaying()); // this is weird and should be unnecessary
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
}
