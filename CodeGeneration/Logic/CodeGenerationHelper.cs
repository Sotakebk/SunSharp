namespace CodeGeneration.Logic;

public static class CodeGenerationHelper
{
    public static void AppendHeader(CodeGenerationContext context)
    {
        context.AppendLine("/*");
        context.AppendLine(" * Do not modify this file manually.");
        context.AppendLine("*/");
        context.AppendLine();
        context.AppendLine("#nullable enable");
        context.AppendLine();
    }
}
