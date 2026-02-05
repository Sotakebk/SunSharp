using SunSharp;
using SunSharp.Modules;
using SunSharp.Redistribution;

var libc = SunVoxLibraryLoader.Load();
using var sunVox = SunVox.WithOwnAudioStream(libc);

if (!sunVox.Slots.TryOpenNewSlot(out var slot))
{
    return -1;
}

// construct a simple arpeggiated melody in a pattern
using (var l = slot.AcquireLock())
{
    var generator = slot.Synthesizer.CreateModule(SynthModuleType.Generator, "generator").AsGenerator();
    generator.SetAttack(0);
    generator.SetSustain(Toggle.Off);
    generator.SetRelease(100);

    var echo = slot.Synthesizer.CreateModule(SynthModuleType.Echo, "echo").AsEcho();
    echo.SetDelayUnit(EchoDelayUnit.OneThirdLine);
    echo.SetDelay(4);
    echo.SetFeedback(60);

    var delay = slot.Synthesizer.CreateModule(SynthModuleType.Delay, "delay").AsDelay();
    delay.SetDelayUnit(DelayUnit.Line);
    delay.SetDelayL(2);
    delay.SetDelayR(3);
    delay.SetInverse(Toggle.On);
    delay.SetWet(250);
    delay.SetDry(512);

    generator.ConnectOutput(delay);
    delay.ConnectOutput(echo);
    echo.ConnectOutput(slot.Synthesizer.Output);

    var chord1 = new[]
    {
        Note.C(4), Note.E(4), Note.G(4), Note.A(4)
    };

    var chord2 = new[]
    {
        Note.A(3), Note.D(4), Note.F(4), Note.G(4)
    };

    var chord3 = new[]
    {
        Note.B(3), Note.C(4), Note.E(4), Note.F(4)
    };

    var chords = new[] { chord1, chord2, chord3, chord1 };

    var indices = new[] { 0, 1, 2, 3, 1, 0 };

    var length = chords.Length * indices.Length * 2;
    var pattern = slot.Timeline.CreatePattern(lines: length + 2, tracks: 1, x: 0, y: 0);

    for (int i = 0; i < length; i += 2)
    {
        var index = indices[i / 2 % indices.Length];
        var chord = (i /2) / indices.Length % chords.Length;

        pattern.SetEvent(0, i, generator.MakeNoteEvent(chords[chord][index]));
    }

    pattern.SetEvent(0, length + 1, generator.MakeNoteEvent(Note.C(4)));
}

slot.VirtualPattern.SetEventTiming(0);
slot.VirtualPattern.SendEvent(0, PatternEvent.EffectEvent(null, Effect.SetBpm, 89));

slot.SetAutomaticStop(true);
slot.StartPlaybackFromBeginning();
List<short[]> buffers = [];
do
{
    Thread.Sleep(100);
} while (slot.IsPlaying() || slot.GetCurrentSignalLevel() > 1);

return 0;
