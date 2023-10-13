namespace SunSharp.Tests.Mocks;

public static class ModuleFlagsHelper
{
    public static uint CreateModuleFlagsValue(bool exists = false, bool isGenerator = false, bool isEffect = false,
        bool isMute = false, bool isSolo = false, bool isBypassed = false, byte inputCount = 0, byte outputCount = 0)
    {
        return ((exists ? 1u : 0) << 0)
               | ((isGenerator ? 1u : 0) << 1)
               | ((isEffect ? 1u : 0) << 2)
               | ((isMute ? 1u : 0) << 3)
               | ((isSolo ? 1u : 0) << 4)
               | ((isBypassed ? 1u : 0) << 5)
               | ((uint)inputCount << 16)
               | ((uint)outputCount << 24);
    }
}
