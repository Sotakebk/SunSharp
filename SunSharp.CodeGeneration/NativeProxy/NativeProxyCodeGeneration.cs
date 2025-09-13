using System.IO;
using SunSharp.CodeGeneration.CodeGenerationTools;

namespace SunSharp.CodeGeneration.NativeProxy;

internal class NativeProxyCodeGeneration
{
    private const string PathToFile = "/SunSharp/Native/Loader/NativeProxy.ISunVoxLibC.Generated.cs";

    [Test]
    public void CheckIfCodeIsUpToDate()
    {
        var path = PathHelper.GetProjectFilePath(PathToFile);
        var generator = new NativeProxyGenerator();
        var oldSourceCode = File.ReadAllText(path);
        var newSourceCode = generator.Generate();

        TestContext.Out.Write(newSourceCode);

        newSourceCode.Should().BeEquivalentTo(oldSourceCode);
    }
}
