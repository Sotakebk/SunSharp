namespace CodeGeneration.Generators
{
    public abstract class AdditionalGenerator
    {
        public CodeGenerationContext Context { get; set; }
        public ReparsedData.Data Data { get; set; }

        public AdditionalGenerator()
        {
        }

        protected string GetTabs() => Context.GetTabs();

        protected void AddIndent(Action action) => Context.AddIndent(action);

        protected void AppendLine(string value = "") => Context.AppendLine(value);

        protected void AppendLineNoTab(string value = "") => Context.AppendLineNoTab(value);

        protected void Append(string value = "") => Context.Append(value);

        public abstract void AppendCode();
    }
}
