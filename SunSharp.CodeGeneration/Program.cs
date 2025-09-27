namespace SunSharp.CodeGeneration;

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
        if (generators.Count == 0)
        {
            Console.WriteLine("No generator types were found.");
            return 0;
        }

        Console.WriteLine($"Discovered {generators.Count} generator(s).");

        // Run all generators
        var resultTasks = generators.Select(g => g.GenerateAsync(Cts.Token));
        var results = await Task.WhenAll(resultTasks);

        var failures = results.Where(r => !r.Successful).ToList();
        if (failures.Count != 0)
        {
            Console.WriteLine("One or more generators failed:");
            foreach (var f in failures)
            {
                Console.WriteLine($"[FAIL] {f.GeneratorType.Name}");
                if (f.Exception is not null) PrintException(f.Exception);
            }
            return -1;
        }

        var withChanges = results.Where(r => r.ChangesNecessary).ToList();
        var unchanged = results.Length - withChanges.Count;

        Console.WriteLine($"Generators completed. Changed: {withChanges.Count}, Unchanged: {unchanged}.");

        if (withChanges.Count == 0)
        {
            Console.WriteLine("No changes are necessary.");
            return 0;
        }

        await Parallel.ForEachAsync(
            withChanges,
            Cts.Token,
            async (result, token) =>
            {
                Console.WriteLine($"Applying changes to '{result.TargetPath}'...");
                await result.ApplyAsync(token);
            });

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
