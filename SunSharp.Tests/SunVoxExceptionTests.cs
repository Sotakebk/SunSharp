using NUnit.Framework;

namespace SunSharp.Tests;

public class SunVoxExceptionTests
{
    [Test]
    public void ShouldHaveExpectedMessage()
    {
        const uint code = unchecked((uint)-1);
        const string methodName = nameof(ShouldHaveExpectedMessage);
        var exception = new SunVoxException(-1, methodName);
        var exceptionFromUint = new SunVoxException(code, methodName);
        var exceptionWithNoMethod = new SunVoxException(-1);

        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Is.EqualTo($"Error code: {code:X}, method: '{methodName}'."));
            Assert.That(exceptionFromUint.Message, Is.EqualTo($"Error code: {code:X}, method: '{methodName}'."));
            Assert.That(exceptionWithNoMethod.Message, Is.EqualTo($"Error code: {code:X}, method: 'unknown'."));
        });
    }
}
