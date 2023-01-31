using SunSharp;
using SunSharp.ThinWrapper;

namespace Examples;

internal class ThinWrapperSendEvents : BaseExample
{
    protected override void RunTest(ISunVoxLib lib)
    {
        WriteLine("Initializing");
        lib.Init(sampleRate: -1);
        WriteLine("Loading the song");
        lib.OpenSlot(0);
        lib.Load(0, "the_lick.sunvox");

        SendNotes(lib);

        lib.CloseSlot(0);
        lib.Deinit();
    }

    private void SendNotes(ISunVoxLib lib)
    {
        var tps = lib.GetTicksPerSecond();
        WriteLine("Sending a few notes.");
        var tpb = (int)(tps * 60f / 80f);
        var data = new (Note note, int time)[] // the lick, lol
        {
            (new Note(NoteName.D, 3), tpb/4), // note, and the time it should be held, in ticks
            (new Note(NoteName.E, 3), tpb/4),
            (new Note(NoteName.F, 3), tpb/4),
            (new Note(NoteName.G, 3), tpb/4),
            (new Note(NoteName.E, 3), tpb * 2/4),
            (new Note(NoteName.C, 3), tpb/4),
            (new Note(NoteName.D, 3), tpb/4),
            (Note.Off, 0)
        };

        int accumulator = 0;
        uint current = lib.GetTicks() + tps / 2;
        foreach (var pair in data)
        {
            lib.SetSendEventTimestamp(0, false, (int)(accumulator + current));
            lib.SendEvent(0, 0, new PatternEvent(pair.note, 0x80, 2));
            accumulator += pair.time;
        }
        lib.SetSendEventTimestamp(0, true);

        var wait = accumulator / (float)tps + 1;
        WriteLine($"Waiting {wait} seconds...");
        Thread.Sleep((int)(wait * 1000));
    }
}
