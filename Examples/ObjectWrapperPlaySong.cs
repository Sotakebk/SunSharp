using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples;

internal class ObjectWrapperPlaySong : BaseExample
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

            slot.SetAutostop(true);
            slot.Rewind(0);
            slot.Play();

            int line = 0;
            while (line != slot.GetSongLengthInLines() - 1 || slot.IsPlaying())
            {
                var currentLine = slot.GetCurrentLine();
                if (currentLine != line)
                {
                    line = currentLine;
                    WriteLine($"Current line: {line}");
                }

                Thread.Sleep(10);
            }

            WriteLine("Song finished");
            Thread.Sleep(1000); // wait a second, so the reverb may fade out a bit...

            slot.Close();
        }
    }
}
