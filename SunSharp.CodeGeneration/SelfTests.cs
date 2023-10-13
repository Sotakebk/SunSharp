using System;
using NUnit.Framework;
using SunSharp.CodeGeneration.CodeGenerationTools;

namespace SunSharp.CodeGeneration;

public class SelfTests
{
    [Test]
    public void PathHelperShouldFailToFindProjectRootDirectoryForInvalidArgument()
    {
        Assert.That(
            static () => PathHelper.GetProjectFilePath("ThisFileDoesNotExist.cs",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),
            Throws.Exception.With.Message.EqualTo("Could not trace back to the project folder."));

        Assert.That(static () => PathHelper.GetProjectFilePath("ThisFileDoesNotExist.cs", null),
            Throws.ArgumentNullException);
    }
}
