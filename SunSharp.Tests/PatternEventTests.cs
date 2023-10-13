using NUnit.Framework;

namespace SunSharp.Tests;

public class PatternEventTests
{
    public static TestCaseData[] TestCases => new[]
    {
        new TestCaseData(new PatternEvent(), "____________"),
        new TestCaseData(new PatternEvent(new Note(NoteName.C, 4), 0x80, 1), "C4800001______"),
        new TestCaseData(new PatternEvent(0, 1), "__________0001"),
        new TestCaseData(new PatternEvent(Effect.Arpeggio, 0x0704), "________080704"),
        new TestCaseData(new PatternEvent(3, 0x01, 0xA9, 0x87, 0x65, 0x4321), "D00100A987654321"),
        new TestCaseData(new PatternEvent(Note.Off), "--__________"),
        new TestCaseData(new PatternEvent(Note.AllNotesOff), "-!__________")
    };

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

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(note), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(note), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(controller), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(effect), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo((controller << 8) | effect), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(module), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)effect), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(xxyy), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(xx), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(yy), "YY");
        });
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

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(0), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(0), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(0), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(effect), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo(effect), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(0), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)effect), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(xxyy), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(xx), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(yy), "YY");
        });
    }

    [Test]
    public void PatternEventConstructorForNoteShouldSetValuesAsExpected()
    {
        const byte note = 0x12;
        const byte velocity = 0x95;
        const ushort module = 0xd93e;

        var binaryValue = ConstructBinaryPatternEventValue(note, velocity, module);
        var patternEvent = new PatternEvent(note, velocity, module);

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(note), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(note), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(0), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(0), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo(0), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(module), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo(Effect.None), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(0), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(0), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(0), "YY");
        });
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

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(note), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(note), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(controller), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(effect), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo((controller << 8) | effect), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(module), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)effect), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(xxyy), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(xx), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(yy), "YY");
        });
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

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(note), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(note), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(controller), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(effect), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo((controller << 8) | effect), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(module), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)effect), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(xxyy), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(xx), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(yy), "YY");
        });
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

        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(binaryValue), "Data");
            Assert.That(patternEvent.NN, Is.EqualTo(note), "NN");
            Assert.That(patternEvent.Note.Value, Is.EqualTo(note), "Note");
            Assert.That(patternEvent.CC, Is.EqualTo(controller), "CC");
            Assert.That(patternEvent.EE, Is.EqualTo(effect), "EE");
            Assert.That(patternEvent.CCEE, Is.EqualTo((controller << 8) | effect), "CCEE");
            Assert.That(patternEvent.MM, Is.EqualTo(module), "MM");
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)effect), "Effect");
            Assert.That(patternEvent.XXYY, Is.EqualTo(xxyy), "XXYY");
            Assert.That(patternEvent.XX, Is.EqualTo(xx), "XX");
            Assert.That(patternEvent.YY, Is.EqualTo(yy), "YY");
        });
    }

    [Test]
    public void PatternEventSettersShouldJustWork()
    {
        var patternEvent = new PatternEvent
        {
            NN = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(1)));
            Assert.That(patternEvent.NN, Is.EqualTo(1));
            Assert.That(patternEvent.Note, Is.EqualTo((Note)1));
        });

        patternEvent = new PatternEvent
        {
            Note = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(1)));
            Assert.That(patternEvent.NN, Is.EqualTo(1));
            Assert.That(patternEvent.Note, Is.EqualTo((Note)1));
        });

        patternEvent = new PatternEvent
        {
            MM = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(module: 1)));
            Assert.That(patternEvent.MM, Is.EqualTo(1));
        });

        patternEvent = new PatternEvent
        {
            VV = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(velocity: 1)));
            Assert.That(patternEvent.VV, Is.EqualTo(1));
        });

        patternEvent = new PatternEvent
        {
            CC = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(controller: 1)));
            Assert.That(patternEvent.CC, Is.EqualTo(1));
        });

        patternEvent = new PatternEvent
        {
            EE = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(effect: 1)));
            Assert.That(patternEvent.EE, Is.EqualTo(1));
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)1));
        });

        patternEvent = new PatternEvent
        {
            Effect = (Effect)1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(effect: 1)));
            Assert.That(patternEvent.EE, Is.EqualTo(1));
            Assert.That(patternEvent.Effect, Is.EqualTo((Effect)1));
        });

        patternEvent = new PatternEvent
        {
            CCEE = 0x0101
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(effect: 1, controller: 1)));
            Assert.That(patternEvent.EE, Is.EqualTo(1));
            Assert.That(patternEvent.CC, Is.EqualTo(1));
            Assert.That(patternEvent.CCEE, Is.EqualTo(0x0101));
        });

        patternEvent = new PatternEvent
        {
            XXYY = 0x0101
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(xxyy: 0x0101)));
            Assert.That(patternEvent.XX, Is.EqualTo(1));
            Assert.That(patternEvent.YY, Is.EqualTo(1));
            Assert.That(patternEvent.XXYY, Is.EqualTo(0x0101));
        });

        patternEvent = new PatternEvent
        {
            XX = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(xxyy: 0x0001)));
            Assert.That(patternEvent.XX, Is.EqualTo(1));
            Assert.That(patternEvent.YY, Is.EqualTo(0));
            Assert.That(patternEvent.XXYY, Is.EqualTo(0x0001));
        });

        patternEvent = new PatternEvent
        {
            YY = 1
        };
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(ConstructBinaryPatternEventValue(xxyy: 0x0100)));
            Assert.That(patternEvent.XX, Is.EqualTo(0));
            Assert.That(patternEvent.YY, Is.EqualTo(1));
            Assert.That(patternEvent.XXYY, Is.EqualTo(0x0100));
        });
    }

    [TestCaseSource(nameof(TestCases))]
    public void PatternEventToStringShouldReturnExpectedValue(PatternEvent patternEvent, string expectedValue)
    {
        Assert.That(patternEvent.ToString(), Is.EqualTo(expectedValue));
    }

    [Test]
    public void PatternEventEqualityComparisonShouldJustWork()
    {
        var a = new PatternEvent(1);
        var b = new PatternEvent(1);
        var c = new PatternEvent(2);

        Assert.Multiple(() =>
        {
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
            Assert.That(a.Equals(b));
            Assert.That(a.Equals(a));
            Assert.That(a.Equals(1));
            Assert.That(a.Equals(1));
            Assert.That(a.Equals((object?)b));
            Assert.That(a.Equals((object?)a));
            Assert.That(a.Equals(null), Is.False);
            Assert.That(a.Equals(new object()), Is.False);
            Assert.That(b.Equals(c), Is.False);
            Assert.That(b.Equals(2), Is.False);
            Assert.That(new Note(1).Equals(2), Is.False);

            Assert.That(a == b);
            Assert.That(a != b, Is.False);
            Assert.That(a == 1);
            Assert.That(a != 2);
            Assert.That(a != c);
            Assert.That(a == c, Is.False);
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
        });
    }

    [Test]
    public void PatternEventGetHashCodeShouldPreserveComparability()
    {
        var a = new PatternEvent(1);
        var b = new PatternEvent(1);
        var c = new PatternEvent(2);

        Assert.Multiple(() =>
        {
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
            Assert.That(a.GetHashCode(), !Is.EqualTo(c.GetHashCode()));
        });
    }

    [TestCase(0ul)]
    [TestCase(1ul)]
    [TestCase(2ul)]
    public void PatternEventImplicitCastShouldJustWork(ulong value)
    {
        var patternEvent = (PatternEvent)value;
        var extractedValue = (ulong)patternEvent;
        Assert.Multiple(() =>
        {
            Assert.That(patternEvent.Data, Is.EqualTo(value));
            Assert.That(extractedValue, Is.EqualTo(patternEvent.Data));
            Assert.That(extractedValue, Is.EqualTo(value));
        });
    }
}
