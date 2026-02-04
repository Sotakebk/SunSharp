namespace CodeGeneration;

internal sealed class Program
{
    private static readonly CancellationTokenSource Cts = new();

    private static async Task<int> Main()
    {
        Console.WriteLine("Starting code generation...");

        Console.CancelKeyPress += (_, eventArgs) =>
        {
            Console.WriteLine("Cancel event triggered");
            Cts.Cancel();
            eventArgs.Cancel = true;
        };

        var generators = GeneratorDiscovery.GetGenerators();
        if (generators.Length == 0)
        {
            Console.WriteLine("No generator types were found.");
            return 0;
        }

        Console.WriteLine($"Discovered {generators.Length} generator(s).");
        var groups = generators.GroupBy(g => g.Priority).OrderByDescending(g => g.Key).ToArray();
        var allResults = new List<GeneratorResult>();
        var totalChanged = 0;
        var totalUnchanged = 0;

        foreach (var group in groups)
        {
            Console.WriteLine($"Processing priority group {group.Key}...");

            var resultTasks = group.Select(g => g.GenerateAsync(Cts.Token));
            var groupResults = await Task.WhenAll(resultTasks);
            allResults.AddRange(groupResults);

            var groupFailures = groupResults.Where(r => !r.Successful).ToList();
            if (groupFailures.Count != 0)
            {
                Console.WriteLine($"One or more generators failed in priority group {group.Key}:");
                foreach (var f in groupFailures)
                {
                    Console.WriteLine($"[FAIL] {f.GeneratorName}");
                    if (f.Exception is not null) PrintException(f.Exception);
                }
                return -1;
            }

            var withChanges = groupResults.Where(r => r.ChangesNecessary).ToList();
            var unchanged = groupResults.Length - withChanges.Count;
            totalChanged += withChanges.Count;
            totalUnchanged += unchanged;

            Console.WriteLine($"Priority group {group.Key} completed. Changed: {withChanges.Count}, Unchanged: {unchanged}.");

            if (withChanges.Count > 0)
            {
                await Parallel.ForEachAsync(
                    withChanges,
                    Cts.Token,
                    async (result, token) =>
                    {
                        Console.WriteLine($"Applying changes to '{result.TargetPath}'...");
                        await result.ApplyAsync(token);
                    });
            }
        }

        Console.WriteLine($"All generators completed. Total Changed: {totalChanged}, Total Unchanged: {totalUnchanged}.");
        Console.WriteLine("All done!");
        return 0;
    }

    private static void PrintException(Exception ex)
    {
        var depth = 0;
        for (var current = ex; current is not null; current = current.InnerException)
        {
            var prefix = depth == 0 ? "   " : new string(' ', (depth + 1) * 3);
            Console.WriteLine($"{prefix}{current.GetType().Name}: {current.Message}");
            if (current.StackTrace is not null) Console.WriteLine($"{prefix}{current.StackTrace}");
            depth++;
        }
    }
}
