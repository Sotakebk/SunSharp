namespace SunSharp.Tests;

public class PatternEventTests
{
    public static TestCaseData[] TestCases =>
    [
        new(new PatternEvent(), "____________"),
        new(new PatternEvent(new Note(NoteName.C, 4), 0x80, 1), "C4800001______"),
        new(new PatternEvent(0, 1), "__________0001"),
        new(new PatternEvent(Effect.Arpeggio, 0x0704), "________080704"),
        new(new PatternEvent(3, 0x01, 0xA9, 0x87, 0x65, 0x4321), "D00100A987654321"),
        new(new PatternEvent(Note.Off), "--__________"),
        new(new PatternEvent(Note.AllNotesOff), "-!__________")
    ];

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
    public void PatternEventConstructorFromBinaryDataShouldSetValuesAsExpected()
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
    public void PatternEventConstructorForEffectShouldSetValuesAsExpected()
    {
        const byte effect = 0x95;
        const ushort xxyy = 0x1010;
        const ushort xx = xxyy & 0xFF;
        const ushort yy = (xxyy >> 8) & 0xFF;

        var binaryValue = ConstructBinaryPatternEventValue(effect: effect, xxyy: xxyy);
        var patternEvent = new PatternEvent((Effect)effect, xxyy);

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
    public void PatternEventConstructorForNoteShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module);
        var patternEvent = new PatternEvent(note, velocity, module);

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
    public void PatternEventConstructorWithAllParametersShouldSetValuesAsExpected()
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
    public void PatternEventConstructorWithAllParametersWithSpecifiedTypesShouldSetValuesAsExpected()
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
        var patternEvent = new PatternEvent(note, velocity, module, controller, (Effect)effect, xxyy);

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
    public void PatternEventConstructorWithAllParametersWithPackedControllerEffectShouldSetValuesAsExpected()
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
        var patternEvent = new PatternEvent(note, velocity, module, (controller << 8) | effect, xxyy);

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
    public void PatternEventSettersShouldJustWork()
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

    [TestCaseSource(nameof(TestCases))]
    public void PatternEventToStringShouldReturnExpectedValue(PatternEvent patternEvent, string expectedValue)
    {
        patternEvent.ToString().Should().Be(expectedValue);
    }

    [Test]
    public void PatternEventEqualityComparisonShouldJustWork()
    {
        var a = new PatternEvent(1);
        var b = new PatternEvent(1);
        var c = new PatternEvent(2);

        a.Equals(b).Should().BeTrue();
        a.Equals(a).Should().BeTrue();
        a.Equals(1).Should().BeTrue();
        a.Equals(1).Should().BeTrue();
        a.Equals((object?)b).Should().BeTrue();
        a.Equals((object?)a).Should().BeTrue();
        a.Equals(null).Should().BeFalse();
        a.Equals(new object()).Should().BeFalse();
        b.Equals(c).Should().BeFalse();
        b.Equals(2).Should().BeFalse();
        new Note(1).Equals(2).Should().BeFalse();

        (a == b).Should().BeTrue();
        (a != b).Should().BeFalse();
        (a == 1).Should().BeTrue();
        (a != 2).Should().BeTrue();
        (a != c).Should().BeTrue();
        (a == c).Should().BeFalse();
    }

    [Test]
    public void PatternEventGetHashCodeShouldPreserveComparability()
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
    public void PatternEventImplicitCastShouldJustWork(ulong value)
    {
        var patternEvent = (PatternEvent)value;
        var extractedValue = (ulong)patternEvent;
        patternEvent.Data.Should().Be(value);
        extractedValue.Should().Be(patternEvent.Data);
        extractedValue.Should().Be(value);
    }
}
