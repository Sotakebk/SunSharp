using System.Text;

namespace CodeGeneration.Generators
{
    public class CodeGenerationContext
    {
        protected StringBuilder _sb = new StringBuilder();
        private int tabs = 0;

        public const bool TabsInsteadOfSpaces = false;

        public string GetTabs() => TabsInsteadOfSpaces ? new string('\t', tabs) : new string(' ', tabs * 4);

        public void AddIndent(Action action)
        {
            tabs++;
            action();
            tabs--;
        }

        public void AppendLine(string value = "")
        {
            if (string.IsNullOrWhiteSpace(value))
                _sb.AppendLine();
            else
                _sb.AppendLine(GetTabs() + value);
        }

        public void AppendLineNoTab(string value = "")
        {
            if (string.IsNullOrWhiteSpace(value))
                _sb.AppendLine();
            else
                _sb.AppendLine(value);
        }

        public void Append(string value = "") => _sb.Append(value);

        public string GetBuiltString() => _sb.ToString();
    }
}
