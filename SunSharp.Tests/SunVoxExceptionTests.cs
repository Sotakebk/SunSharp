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

        exception.Message.Should().Be($"Error code: {code:X}, method: '{methodName}'.");
        exceptionFromUint.Message.Should().Be($"Error code: {code:X}, method: '{methodName}'.");
        exceptionWithNoMethod.Message.Should().Be($"Error code: {code:X}, method: 'unknown'.");
    }
}
