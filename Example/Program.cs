using Examples.ExampleCode;
using SunSharp;

namespace Examples
{
    internal static partial class Program
    {
        private static Dictionary<int, (string name, Action<ISunVoxLib> action)> Options = new Dictionary<int, (string, Action<ISunVoxLib>)>()
        {
            {1, ("Thin wrapper example", ThinWrapperExample.RunExample) },
            {2, ("Object oriented example", ObjectOrientedExample.RunExample) },
            {3, ("Jump graph example", JumpGraphExample.RunExample) },
            {4, ("Lock test", LockCodeTest.RunExample) }
        };

        private static void Main(string[] args)
        {
            Console.WriteLine($"Select an option:");
            foreach (var option in Options)
            {
                Console.WriteLine($"{option.Key}: {option.Value.name}.");
            }
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                if (Options.TryGetValue(i, out var value))
                {
                    try
                    {
                        SunSharp.Redistribution.Redistribution.LoadLibrary();
                        var lib = SunSharp.Redistribution.Redistribution.GetLibrary();
                        value.action(lib);
                    }
                    finally
                    {
                        SunSharp.Redistribution.Redistribution.UnloadLibrary();
                    }
                }
            }
        }
    }
}
