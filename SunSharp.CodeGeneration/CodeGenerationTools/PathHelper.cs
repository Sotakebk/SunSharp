using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SunSharp.CodeGeneration.CodeGenerationTools
{
    public static class PathHelper
    {
        public static string GetProjectFilePath(string pathFromRoot, [CallerFilePath] string? callerFilePath = null)
        {
            var expectedFolders = new string[]
            {
                "SunSharp",
                "SunSharp.CodeGeneration",
                "SunSharp.IntegrationTests",
                "SunSharp.Redistribution",
                "SunSharp.UnitTests",
            };

            ArgumentNullException.ThrowIfNull(callerFilePath);

            var fileInfo = new FileInfo(callerFilePath);
            var directoryInfo = fileInfo.Directory;
            while (directoryInfo != null && directoryInfo.Exists)
            {
                var directories = directoryInfo.GetDirectories();
                if (expectedFolders.All(f => directories.Any(d => d.Name == f)))
                    break;
                else
                {
                    directoryInfo = directoryInfo.Parent;
                }
            }

            // is current directoryInfo the folder we expected?
            if (directoryInfo != null && expectedFolders.All(f => directoryInfo.GetDirectories().Any(d => d.Name == f)))
            {
                return Path.Join(directoryInfo.FullName, pathFromRoot);
            }
            else
            {
                throw new Exception("Could not trace back to the project folder.");
            }
        }
    }
}
