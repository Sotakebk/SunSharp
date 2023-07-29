using System;

namespace SunSharp.CodeGeneration.CodeGenerationTools;

public abstract class BaseGenerator
{
    protected CodeGenerationContext Context = new();

    protected virtual string GetTabs() => Context.GetTabs();

    protected virtual void AddIndent(Action action) => Context.AddIndent(action);

    protected virtual void AppendLine(string value = "") => Context.AppendLine(value);

    protected virtual void AppendLineNoTab(string value = "") => Context.AppendLineNoTab(value);

    protected virtual void Append(string value = "") => Context.Append(value);

    public virtual string Generate()
    {
        return GenerateBody();
    }

    protected abstract string GenerateBody();
}