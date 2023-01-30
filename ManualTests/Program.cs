using ManualJobs.Tests;

namespace ManualJobs
{
    internal static partial class Program
    {
        internal static string SunVoxProjectFolder = "SunVoxProjects";

        private static Dictionary<int, ManualTestContainer> Options = new Dictionary<int, ManualTestContainer>()
        {
            {1, new ManualJobContainer<ThinWrapperTest>("Thin wrapper test")},
            {2, new ManualJobContainer<ObjectOrientedTest>("Object wrapper test")},
            {3, new ManualJobContainer<JumpGraphTest>("Jump graph test")},
        };

        private static void Main(string[] args)
        {
            Console.WriteLine($"Select an option:");
            foreach (var option in Options)
                Console.WriteLine($"{option.Key}: {option.Value.Name}.");

            if (int.TryParse(Console.ReadLine(), out int i))
            {
                if (Options.TryGetValue(i, out var option))
                    option.Run();
            }
        }
    }
}
