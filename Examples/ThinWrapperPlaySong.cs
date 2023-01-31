using SunSharp;
using SunSharp.ThinWrapper;

namespace Examples;

internal class ThinWrapperPlaySong : BaseExample
{
    protected override void RunTest(ISunVoxLib lib)
    {
        WriteLine("Initializing");
        lib.Init(sampleRate: -1);
        WriteLine("Loading the song");
        lib.OpenSlot(0);
        lib.Load(0, "the_lick.sunvox");
        WriteLine($"Loaded song: {lib.GetSongName(0)}");
        lib.SetAutostop(0, autostop: true);
        lib.Rewind(0, line: 0);
        WriteLine("Playing the song");
        lib.Play(0);

        int line = 0;
        while (line != lib.GetSongLengthInLines(0) - 1 || lib.IsPlaying(0))
        {
            var currentLine = lib.GetCurrentLine(0);
            if (currentLine != line)
            {
                line = currentLine;
                WriteLine($"Current line: {line}");
            }
            Thread.Sleep(10);
        }
        WriteLine("Song finished");
        Thread.Sleep(1000); // wait a second, so the reverb may fade out a bit...

        lib.CloseSlot(0);
        lib.Deinit();
    }
}
