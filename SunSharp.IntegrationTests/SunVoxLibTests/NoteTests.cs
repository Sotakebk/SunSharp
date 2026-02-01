using System.IO;

namespace SunSharp.IntegrationTests.SunVoxLibTests;

internal class NoteTests : BaseIntegrationTests
{
    private string TestFilePath => Path.Join(base.GetTestPath(), "all_notes.sunvox");

    [Test]
    public void AllNotes_ShouldBeReadAsExpected()
    {
        const int slotId = 0;
        Lib.OpenSlot(slotId);
        Lib.Load(slotId, TestFilePath);
        Lib.LockSlot(slotId);

        var result = Lib.GetPatternData(slotId, 0);
        result.Should().NotBeNull();

        var (data, tracks, lines) = result.Value;
        tracks.Should().Be(1);
        lines.Should().Be(256);
        data.Should().HaveCount(tracks * lines);

        for (var i = 0; i < lines; i++)
        {
            data[i].Note.Should().Be((byte)i);
        }

        // compares what is shown in sunvox vs what is set up in library
        data[0].Note.Should().Be(Note.Nothing);
        for (var o = 0; o < 10; o++)
        {
            data[o * 12 + 1].Note.Should().Be(Note.C(o));
            data[o * 12 + 2].Note.Should().Be(Note.Cs(o));
            data[o * 12 + 3].Note.Should().Be(Note.D(o));
            data[o * 12 + 4].Note.Should().Be(Note.Ds(o));
            data[o * 12 + 5].Note.Should().Be(Note.E(o));
            data[o * 12 + 6].Note.Should().Be(Note.F(o));
            data[o * 12 + 7].Note.Should().Be(Note.Fs(o));
            data[o * 12 + 8].Note.Should().Be(Note.G(o));
            data[o * 12 + 9].Note.Should().Be(Note.Gs(o));
            data[o * 12 + 10].Note.Should().Be(Note.A(o));
            data[o * 12 + 11].Note.Should().Be(Note.As(o));
            data[o * 12 + 12].Note.Should().Be(Note.B(o));
        }
        data[121].Note.Should().Be(Note.C(0xA));
        data[122].Note.Should().Be(Note.Cs(0xA));
        data[123].Note.Should().Be(Note.D(0xA));
        data[124].Note.Should().Be(Note.Ds(0xA));
        data[125].Note.Should().Be(Note.E(0xA));
        data[126].Note.Should().Be(Note.F(0xA));
        data[127].Note.Should().Be(Note.Fs(0xA));
        data[128].Note.Should().Be(Note.Off);
        data[133].Note.Should().Be(Note.SetPitch);
    }
}

