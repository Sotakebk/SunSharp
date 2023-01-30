using System.Text;

namespace CodeGeneration
{
    internal abstract class BaseGenerator
    {
        protected StringBuilder _sb = new StringBuilder();
        private int tabs = 0;

        public const bool TabsInsteadOfSpaces = false;

        protected string GetTabs() => (TabsInsteadOfSpaces) ? new string('\t', tabs) : new string(' ', tabs * 4);

        protected void AddIndent(Action action)
        {
            tabs++;
            action();
            tabs--;
        }

        protected void AppendLine(string value = "")
        {
            if (string.IsNullOrWhiteSpace(value))
                _sb.AppendLine();
            else
                _sb.AppendLine(GetTabs() + value);
        }

        protected void Append(string value = "") => _sb.Append(value);

        internal bool Generate(string filePath)
        {
            GenerateBody();
            var content = _sb.ToString();

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
