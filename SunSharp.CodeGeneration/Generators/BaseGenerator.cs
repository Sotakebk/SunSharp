namespace SunSharp.CodeGeneration.Generators;

public abstract class BaseGenerator
{
    protected CodeGenerationContext Context = new();

    public abstract string FilePath { get; }

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
