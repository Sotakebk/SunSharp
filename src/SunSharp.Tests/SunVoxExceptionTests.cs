namespace SunSharp.Tests;

public class SunVoxExceptionTests
{
    [Test]
    public void Constructor_ShouldHaveExpectedMessage()
    {
        const uint code = unchecked((uint)-1);
        const string methodName = nameof(Constructor_ShouldHaveExpectedMessage);
        var exception = new SunVoxException(-1, methodName);
        var exceptionFromUint = new SunVoxException(code, methodName);
        var exceptionWithNoMethod = new SunVoxException(-1);

        exception.Message.Should().Be($"Received error code {code:X} from method: {methodName}.");
        exceptionFromUint.Message.Should().Be($"Received error code {code:X} from method: {methodName}.");
        exceptionWithNoMethod.Message.Should().Be($"Received error code {code:X} from method: unknown.");
    }
}
