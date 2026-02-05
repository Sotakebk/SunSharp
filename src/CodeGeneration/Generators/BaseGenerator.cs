using CodeGeneration.Logic;

namespace CodeGeneration.Generators;

public abstract class BaseGenerator
{
    protected CodeGenerationContext Context = new();

    public abstract string FilePath { get; }

    public abstract string Name { get; }

    public virtual int Priority { get => 0; }

    protected virtual void AddIndent(Action action)
    {
        Context.AddIndent(action);
    }

    protected virtual void AppendLine(string value = "")
    {
        Context.AppendLine(value);
    }

    protected virtual void AppendLineNoTab(string value = "")
    {
        Context.AppendLineNoTab(value);
    }

    public virtual string Generate()
    {
        return GenerateBody();
    }

    protected abstract string GenerateBody();
}
