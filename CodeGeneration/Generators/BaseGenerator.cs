namespace CodeGeneration.Generators
{
    internal abstract class BaseGenerator
    {
        protected CodeGenerationContext Context = new CodeGenerationContext();

        protected string GetTabs() => Context.GetTabs();

        protected void AddIndent(Action action) => Context.AddIndent(action);

        protected void AppendLine(string value = "") => Context.AppendLine(value);

        protected void AppendLineNoTab(string value = "") => Context.AppendLineNoTab(value);

        protected void Append(string value = "") => Context.Append(value);

        internal bool Generate(string filePath)
        {
            GenerateBody();
            var content = Context.GetBuiltString();

            var existingFile = File.Exists(filePath) ? File.ReadAllText(filePath) : null;
            if (existingFile == content)
                return false;
            using (var file = File.CreateText(filePath))
            {
                file.Write(content);
                file.Flush();
                file.Close();
            }
            return true;
        }

        protected abstract void GenerateBody();
    }
}
