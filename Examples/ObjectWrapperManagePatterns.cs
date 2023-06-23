using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples;

internal class ObjectWrapperManagePatterns : BaseExample
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

            var pattern = slot.Timeline.First(); // expect only one pattern
            pattern.Resize(lines: pattern.GetLength() + 2);

            var tracks = pattern.GetTrackCount();
            var lines = pattern.GetLength();

            var cloneX = pattern.GetPosition().x + pattern.GetLength();
            var clone = slot.Timeline.ClonePattern(pattern, cloneX, 0);

            var copyX = clone.GetPosition().x + clone.GetLength();
            var copy = slot.Timeline.CreatePattern("Inverted pattern", lines, tracks, copyX, 0);

            var data = pattern.GetData2D();
            var newData = new PatternEvent[lines, tracks];

            for (int l = 0; l < lines; l++)
            {
                for (int t = 0; t < tracks; t++)
                {
                    newData[l, t] = data[lines - 1 - l, tracks - t - 1];
                }
            }

            copy.SetData2D(newData);
            copy.Resize(tracks: 1);

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
