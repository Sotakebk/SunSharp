using SunSharp;

namespace Examples;

public abstract class BaseExample
{
    public void Run()
    {
        try
        {
            SunSharp.Redistribution.Redistribution.LoadLibrary();
            var lib = SunSharp.Redistribution.Redistribution.GetLibrary();
            RunTest(lib);
        }
        finally
        {
            SunSharp.Redistribution.Redistribution.UnloadLibrary();
        }
    }

    protected abstract void RunTest(ISunVoxLib lib);

    protected virtual void WriteLine(string message) => Console.WriteLine(message);

    protected virtual void Write(string message) => Console.Write(message);

    protected virtual string ReadLine() => Console.ReadLine();

    protected virtual void WaitForInput(string message = null)
    {
        if (message == null)
            Console.WriteLine(message);
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }
}
