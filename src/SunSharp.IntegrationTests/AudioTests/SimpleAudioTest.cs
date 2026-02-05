#if !SUNSHARP_GENERATION

using System.Collections.Generic;
using System.Linq;

namespace SunSharp.IntegrationTests.AudioTests;

internal class SimpleAudioTest : BaseAudioTest
{
    [Test]
    public void SimpleArpeggio()
    {
        const string hash = "FLBVvS3nffTDsajOlBeceZsIero8UpCd4RFwyXhJBVM=";
        const int sampleRate = 44100;

        using var sunVox = MakeSunVoxWithUserManagedAudio(sampleRate, OutputType.Int16);

        if (!sunVox.Slots.TryOpenNewSlot(out var slot))
        {
            Assert.Fail("Failed to open new slot");
            return;
        }

        using (var l = slot.AcquireLock())
        {
            var module = slot.Synthesizer.CreateModule(SynthModuleType.Generator, "generator").AsGenerator();

            module.ConnectOutput(slot.Synthesizer.GetModule(0));

            var pattern = slot.Timeline.CreatePattern(64, 1, 0, 0);

            // arpeggiate a Cmaj7 chord up and down

            var notes = new[]
            {
                    Note.C(4), Note.E(4), Note.G(4), Note.B(4), Note.C(5)
            };
            var indices = new[] { 0, 1, 2, 3, 4, 3, 2, 1 };
            for (int i = 0; i < 64; i += 2)
            {
                var index = indices[(i / 2) % indices.Length];

                pattern.SetEvent(0, i, module.MakeNoteEvent(notes[index]));
            }
        }

        slot.SetAutomaticStop(true);
        slot.StartPlaybackFromBeginning();
        List<short[]> buffers = [];
        do
        {
            var buffer = new short[2048];
            sunVox.AudioCallback(buffer, 0, sunVox.GetTicks());
            buffers.Add(buffer);
        } while (slot.IsPlaying());

        var result = new short[buffers.Sum(b => b.Length)];
        var bi = 0;
        foreach (var b in buffers)
        {
            b.CopyTo(result, bi);
            bi += b.Length;
        }

        var final = ToWave(result, sampleRate, 2);
        slot.SaveToFile(GetTestAudioPath("SimpleAudioTest.sunvox"));
        TestResultantAudio(final, hash, "SimpleAudioTest.wav");
    }
}

#endif
