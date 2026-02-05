using System.Runtime.CompilerServices;

namespace CodeGeneration;

public static class PathHelper
{
    public static string GetProjectFilePath(string pathFromRoot, [CallerFilePath] string? callerFilePath = null)
    {
        var expectedFolders = new[]
        {
            "CodeGeneration",
            "CodeGeneration.Tests",
            "SunSharp",
            "SunSharp.IntegrationTests",
            "SunSharp.Redistribution",
            "SunSharp.Tests"
        };

        ArgumentNullException.ThrowIfNull(callerFilePath);

        var fileInfo = new FileInfo(callerFilePath);
        var directoryInfo = fileInfo.Directory;
        while (directoryInfo is { Exists: true })
        {
            var directories = directoryInfo.GetDirectories();
            if (expectedFolders.All(f => directories.Any(d => d.Name == f)))
            {
                return Path.Join(directoryInfo.FullName, pathFromRoot);
            }

            directoryInfo = directoryInfo.Parent;
        }

        throw new Exception("Could not trace back to the project folder.");
    }
}
