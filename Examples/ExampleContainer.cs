namespace Examples;

public abstract class ExampleContainer
{
    public string Name { get; protected set; }

    public ExampleContainer(string name)
    {
        Name = name;
    }

    public abstract void Run();
}

public class ManualJobContainer<T> : ExampleContainer
    where T : BaseExample, new()
{
    public ManualJobContainer(string name) : base(name)
    {
    }

    public override void Run()
    {
        var instance = new T();
        instance.Run();
    }
}
