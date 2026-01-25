namespace SunSharp.Tests;

public class PatternEventTests
{
    private static ulong ConstructBinaryPatternEventValue(byte note = 0, byte velocity = 0, ushort module = 0,
        byte controller = 0, byte effect = 0, ushort xxyy = 0)
    {
        return note // 1 byte
               | ((ulong)velocity << 8) // 1 byte
               | ((ulong)module << (8 * 2)) // 2 bytes
               | ((ulong)effect << (8 * 4)) // 1 byte
               | ((ulong)controller << (8 * 5)) // 1 byte
               | ((ulong)xxyy << (8 * 6)); // 2 bytes
    }

    [Test]
    public void Constructor_FromBinaryData_ShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;
        const byte controller = 0x12;
        const byte effect = 0x95;
        const ushort xxyy = 0x1011;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module, controller, effect, xxyy);
        var patternEvent = new PatternEvent(binaryValue);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(note);
        patternEvent.Note.Value.Should().Be(note);
        patternEvent.CC.Should().Be(controller);
        patternEvent.EE.Should().Be(effect);
        patternEvent.CCEE.Should().Be((controller << 8) | effect);
        patternEvent.MM.Should().Be(module);
        patternEvent.Effect.Should().Be((Effect)effect);
        patternEvent.XXYY.Should().Be(xxyy);
        patternEvent.XX.Should().Be((byte)xx);
        patternEvent.YY.Should().Be((byte)yy);
    }

    [Test]
    public void Constructor_ForEffect_ShouldSetValuesAsExpected()
    {
        const byte effect = 0x95;
        const ushort xxyy = 0x1010;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(effect: effect, xxyy: xxyy);
        var patternEvent = new PatternEvent(0, 0, 0, 0, effect, xxyy);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(0);
        patternEvent.Note.Value.Should().Be(0);
        patternEvent.CC.Should().Be(0);
        patternEvent.EE.Should().Be(effect);
        patternEvent.CCEE.Should().Be(effect);
        patternEvent.MM.Should().Be(0);
        patternEvent.Effect.Should().Be((Effect)effect);
        patternEvent.XXYY.Should().Be(xxyy);
        patternEvent.XX.Should().Be((byte)xx);
        patternEvent.YY.Should().Be((byte)yy);
    }

    [Test]
    public void Constructor_ForNote_ShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module);
        var patternEvent = new PatternEvent(note, velocity, module, 0, 0, 0);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(note);
        patternEvent.Note.Value.Should().Be(note);
        patternEvent.CC.Should().Be(0);
        patternEvent.EE.Should().Be(0);
        patternEvent.CCEE.Should().Be(0);
        patternEvent.MM.Should().Be(module);
        patternEvent.Effect.Should().Be(Effect.None);
        patternEvent.XXYY.Should().Be(0);
        patternEvent.XX.Should().Be(0);
        patternEvent.YY.Should().Be(0);
    }

    [Test]
    public void Constructor_WithAllParameters_ShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;
        const byte controller = 0x12;
        const byte effect = 0x95;
        const ushort xxyy = 0x1011;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module, controller, effect, xxyy);
        var patternEvent = new PatternEvent(note, velocity, module, controller, effect, xxyy);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(note);
        patternEvent.Note.Value.Should().Be(note);
        patternEvent.CC.Should().Be(controller);
        patternEvent.EE.Should().Be(effect);
        patternEvent.CCEE.Should().Be((controller << 8) | effect);
        patternEvent.MM.Should().Be(module);
        patternEvent.Effect.Should().Be((Effect)effect);
        patternEvent.XXYY.Should().Be(xxyy);
        patternEvent.XX.Should().Be((byte)xx);
        patternEvent.YY.Should().Be((byte)yy);
    }

    [Test]
    public void Constructor_WithAllParametersWithSpecifiedTypes_ShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;
        const byte controller = 0x12;
        const byte effect = 0x95;
        const ushort xxyy = 0x1011;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module, controller, effect, xxyy);
        var patternEvent = new PatternEvent(note, velocity, module, controller, effect, xxyy);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(note);
        patternEvent.Note.Value.Should().Be(note);
        patternEvent.CC.Should().Be(controller);
        patternEvent.EE.Should().Be(effect);
        patternEvent.CCEE.Should().Be((controller << 8) | effect);
        patternEvent.MM.Should().Be(module);
        patternEvent.Effect.Should().Be((Effect)effect);
        patternEvent.XXYY.Should().Be(xxyy);
        patternEvent.XX.Should().Be((byte)xx);
        patternEvent.YY.Should().Be((byte)yy);
    }

    [Test]
    public void Constructor_WithAllParametersWithPackedControllerEffect_ShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;
        const byte controller = 0x12;
        const byte effect = 0x95;
        const ushort xxyy = 0x1011;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module, controller, effect, xxyy);
        var patternEvent = new PatternEvent(note, velocity, module, controller, effect, xxyy);

        patternEvent.Data.Should().Be(binaryValue);
        patternEvent.NN.Should().Be(note);
        patternEvent.Note.Value.Should().Be(note);
        patternEvent.CC.Should().Be(controller);
        patternEvent.EE.Should().Be(effect);
        patternEvent.CCEE.Should().Be((controller << 8) | effect);
        patternEvent.MM.Should().Be(module);
        patternEvent.Effect.Should().Be((Effect)effect);
        patternEvent.XXYY.Should().Be(xxyy);
        patternEvent.XX.Should().Be((byte)xx);
        patternEvent.YY.Should().Be((byte)yy);
    }

    [Test]
    public void Setters_ShouldJustWork()
    {
        var patternEvent = new PatternEvent
        {
            NN = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(1));
        patternEvent.NN.Should().Be(1);
        patternEvent.Note.Should().Be((Note)1);

        patternEvent = new PatternEvent
        {
            Note = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(1));
        patternEvent.NN.Should().Be(1);
        patternEvent.Note.Should().Be((Note)1);

        patternEvent = new PatternEvent
        {
            MM = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(module: 1));
        patternEvent.MM.Should().Be(1);

        patternEvent = new PatternEvent
        {
            VV = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(velocity: 1));
        patternEvent.VV.Should().Be(1);

        patternEvent = new PatternEvent
        {
            CC = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(controller: 1));
        patternEvent.CC.Should().Be(1);

        patternEvent = new PatternEvent
        {
            EE = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(effect: 1));
        patternEvent.EE.Should().Be(1);
        patternEvent.Effect.Should().Be((Effect)1);

        patternEvent = new PatternEvent
        {
            Effect = (Effect)1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(effect: 1));
        patternEvent.EE.Should().Be(1);
        patternEvent.Effect.Should().Be((Effect)1);

        patternEvent = new PatternEvent
        {
            CCEE = 0x0101
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(effect: 1, controller: 1));
        patternEvent.EE.Should().Be(1);
        patternEvent.CC.Should().Be(1);
        patternEvent.CCEE.Should().Be(0x0101);

        patternEvent = new PatternEvent
        {
            XXYY = 0x0101
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(xxyy: 0x0101));
        patternEvent.XX.Should().Be(1);
        patternEvent.YY.Should().Be(1);
        patternEvent.XXYY.Should().Be(0x0101);

        patternEvent = new PatternEvent
        {
            XX = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(xxyy: 0x0001));
        patternEvent.XX.Should().Be(1);
        patternEvent.YY.Should().Be(0);
        patternEvent.XXYY.Should().Be(0x0001);

        patternEvent = new PatternEvent
        {
            YY = 1
        };
        patternEvent.Data.Should().Be(ConstructBinaryPatternEventValue(xxyy: 0x0100));
        patternEvent.XX.Should().Be(0);
        patternEvent.YY.Should().Be(1);
        patternEvent.XXYY.Should().Be(0x0100);
    }

    public static TestCaseData[] TestCases =>
    [
        //                                                       "NNVVMMMMCCEEXXYY"
        new(new PatternEvent(),                                  "                "),
        new(new PatternEvent(Note.C(4), 0x81, 1, 0, 0, 0),       "C4800000        "),
        new(new PatternEvent(Note.C(10), 0x81, 1, 0, 0, 0),      "CA800000        "),
        new(new PatternEvent(0, 0, 0, 0, 0, 1),                  "            0001"),
        new(new PatternEvent(0, 0, 0, 0, 0x08, 0x0704),          "          080704"),
        new(new PatternEvent(3, 0x01, 0xA9, 0x87, 0x65, 0x4321), "D00000A887654321"),
        new(new PatternEvent(Note.Off, 0, 0, 0, 0, 0),           "--              "),
        new(new PatternEvent(Note.AllNotesOff, 0, 0, 0, 0, 0),   "-!              ")
    ];

    [TestCaseSource(nameof(TestCases))]
    public void ToString_ShouldReturnExpectedValue(PatternEvent patternEvent, string expectedValue)
    {
        patternEvent.ToString().Should().Be(expectedValue);
    }

    [Test]
    public void EqualityComparison_ShouldJustWork()
    {
        var a = new PatternEvent(1);
        var b = new PatternEvent(1);
        var c = new PatternEvent(2);

        a.Equals(b).Should().BeTrue();
        a.Equals(a).Should().BeTrue();
        a.Equals(1ul).Should().BeTrue();
        a.Equals((object?)b).Should().BeTrue();
        a.Equals((object?)a).Should().BeTrue();
        a.Equals(null).Should().BeFalse();
        a.Equals(new object()).Should().BeFalse();
        b.Equals(c).Should().BeFalse();

        (a == b).Should().BeTrue();
        (a != b).Should().BeFalse();
        (a == 1).Should().BeTrue();
        (a != 2).Should().BeTrue();
        (a != c).Should().BeTrue();
        (a == c).Should().BeFalse();
    }

    [Test]
    public void GetHashCode_ShouldPreserveComparability()
    {
        var a = new PatternEvent(1);
        var b = new PatternEvent(1);
        var c = new PatternEvent(2);

        a.GetHashCode().Should().Be(b.GetHashCode());
        a.GetHashCode().Should().NotBe(c.GetHashCode());
    }

    [TestCase(0ul)]
    [TestCase(1ul)]
    [TestCase(2ul)]
    public void ImplicitCast_ShouldJustWork(ulong value)
    {
        var patternEvent = (PatternEvent)value;
        var extractedValue = (ulong)patternEvent;
        patternEvent.Data.Should().Be(value);
        extractedValue.Should().Be(patternEvent.Data);
        extractedValue.Should().Be(value);
    }

    [Test]
    public void NoteEvent_ShouldWork()
    {
        var note = new Note(NoteName.C, 4);
        var moduleId = 0;
        byte velocity = 100;

        var patternEvent = PatternEvent.NoteEvent(note, moduleId, velocity);

        patternEvent.Note.Should().Be(note);
        patternEvent.ModuleId.Should().Be(moduleId);
        patternEvent.Velocity.Should().Be(velocity);
        patternEvent.ControllerId.Should().BeNull();
        patternEvent.Effect.Should().Be(Effect.None);
        patternEvent.Value.Should().Be(0);
    }

    [Test]
    public void ControllerEvent_ShouldWork()
    {
        const int moduleId = 0;
        const byte controller = 1;
        const ushort value = 16384;

        var patternEvent = PatternEvent.ControllerEvent(moduleId, controller, value);

        patternEvent.ModuleId.Should().Be(moduleId);
        patternEvent.ControllerId.Should().Be(controller);
        patternEvent.Value.Should().Be(value);
        patternEvent.Note.Should().Be(Note.Nothing);
        patternEvent.Velocity.Should().BeNull();
        patternEvent.Effect.Should().Be(Effect.None);
    }

    [Test]
    public void EffectEvent_ShouldWork()
    {
        const int moduleId = 0;
        const Effect effect = Effect.SlideUp;
        const ushort value = 0x100;

        var patternEvent = PatternEvent.EffectEvent(moduleId, effect, value);

        patternEvent.ModuleId.Should().Be(moduleId);
        patternEvent.Effect.Should().Be(effect);
        patternEvent.Value.Should().Be(value);
        patternEvent.Note.Should().Be(Note.Nothing);
        patternEvent.Velocity.Should().BeNull();
        patternEvent.ControllerId.Should().BeNull();
    }

    [Test]
    public void SetPitchEvent_ShouldWork()
    {
        const int moduleId = 0;
        const ushort pitch = 0x3C00;
        byte velocity = 100;

        var patternEvent = PatternEvent.SetPitchEvent(moduleId, pitch, velocity);

        patternEvent.Note.Should().Be(Note.SetPitch);
        patternEvent.ModuleId.Should().Be(moduleId);
        patternEvent.Velocity.Should().Be(velocity);
        patternEvent.Value.Should().Be(pitch);
    }

    [Test]
    public void NewEvent_ShouldWork()
    {
        var note = new Note(NoteName.C, 4);
        const byte velocity = 100;
        const int moduleId = 0;
        const byte controller = 1;
        const Effect effect = Effect.SlideUp;
        const ushort value = 0x1000;

        var patternEvent = PatternEvent.NewEvent(note, velocity, moduleId, controller, effect, value);

        patternEvent.Note.Should().Be(note);
        patternEvent.Velocity.Should().Be(velocity);
        patternEvent.ModuleId.Should().Be(moduleId);
        patternEvent.ControllerId.Should().Be(controller);
        patternEvent.Value.Should().Be(value);
    }

    [Test]
    public void Merge_ShouldWork()
    {
        var first = new PatternEvent(1, 2, 3, 4, 5, 6);
        var second = new PatternEvent(0, 20, 0, 40, 0, 60);

        var merged = PatternEvent.Merge(first, second);

        merged.NN.Should().Be(1);
        merged.VV.Should().Be(20);
        merged.MM.Should().Be(3);
        merged.CC.Should().Be(40);
        merged.EE.Should().Be(5);
        merged.XXYY.Should().Be(60);
    }

    [Test]
    public void FriendlyProperties_ShouldHandleOffsetsCorrectly()
    {
        var patternEvent = new PatternEvent
        {
            Velocity = 100,
            ModuleId = 5,
            ControllerId = 10
        };

        patternEvent.VV.Should().Be(101);
        patternEvent.Velocity.Should().Be(100);
        patternEvent.MM.Should().Be(6);
        patternEvent.ModuleId.Should().Be(5);
        patternEvent.CC.Should().Be(11);
        patternEvent.ControllerId.Should().Be(10);
    }

    [Test]
    public void FriendlyProperties_ShouldHandleNullValues()
    {
        var patternEvent = new PatternEvent
        {
            Velocity = null,
            ModuleId = null,
            ControllerId = null
        };

        patternEvent.VV.Should().Be(0);
        patternEvent.Velocity.Should().BeNull();
        patternEvent.MM.Should().Be(0);
        patternEvent.ModuleId.Should().BeNull();
        patternEvent.CC.Should().Be(0);
        patternEvent.ControllerId.Should().BeNull();
    }

    [Test]
    public void FriendlyProperties_ShouldWorkCorrectly()
    {
        var empty = new PatternEvent();
        empty.HasNote.Should().BeFalse();
        empty.HasVelocity.Should().BeFalse();
        empty.HasModule.Should().BeFalse();
        empty.HasController.Should().BeFalse();
        empty.HasEffect.Should().BeFalse();
        empty.HasValue.Should().BeFalse();
        empty.IsEmpty.Should().BeTrue();

        var noteEvent = PatternEvent.NoteEvent(Note.C(4), 0, 100);
        noteEvent.HasNote.Should().BeTrue();
        noteEvent.HasVelocity.Should().BeTrue();
        noteEvent.HasModule.Should().BeTrue();
        noteEvent.IsEmpty.Should().BeFalse();
    }
}
