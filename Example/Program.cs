namespace Examples
{
    internal static partial class Program
    {
        private static Dictionary<int, (string name, Action action)> Options = new Dictionary<int, (string, Action)>()
        {
            {1, ("Thin wrapper example", ThinWrapperExample.RunExample) },
            {2, ("Object oriented example", ObjectOrientedExample.RunExample) },
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
                    value.action();
                }
            }
        }
    }
}
