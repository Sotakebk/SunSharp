using SunSharp;
using SunSharp.ObjectWrapper;

namespace Examples;

internal class ObjectWrapperSendEvents : BaseExample
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
            SendNotes(slot);
            slot.Close();
        }
    }

    private void SendNotes(Slot slot)
    {
        var vp = slot.VirtualPattern;
        var ticksPerSecond = vp.GetTicksPerSecond();
        WriteLine("Sending a few notes.");
        var ticksPerBeat = (int)(ticksPerSecond * 60f / 80f);
        var data = new (Note note, int time)[] // the lick, lol
        {
            (new Note(NoteName.D, 3), ticksPerBeat / 4), // note, and the time it should be held, in ticks
            (new Note(NoteName.E, 3), ticksPerBeat / 4),
            (new Note(NoteName.F, 3), ticksPerBeat / 4),
            (new Note(NoteName.G, 3), ticksPerBeat / 4),
            (new Note(NoteName.E, 3), ticksPerBeat * 2 / 4),
            (new Note(NoteName.C, 3), ticksPerBeat / 4),
            (new Note(NoteName.D, 3), ticksPerBeat / 4),
            (Note.Off, 0)
        };

        int accumulator = 0;
        uint current = vp.GetCurrentTick() + ticksPerSecond / 2;
        foreach (var pair in data)
        {
            vp.SetEventTiming((int)(accumulator + current));
            vp.SendEvent(0, new PatternEvent(pair.note, 0x80, 2));
            accumulator += pair.time;
        }

        vp.ResetEventTiming();

        var wait = accumulator / (float)ticksPerSecond + 1;
        WriteLine($"Waiting {wait} seconds...");
        Thread.Sleep((int)(wait * 1000));
    }
}
