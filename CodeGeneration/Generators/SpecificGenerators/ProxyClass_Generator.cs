using SunSharp;
using System.Reflection;

namespace CodeGeneration.Generators.SpecificGenerators
{
    internal class ProxyClass_Generator : BaseGenerator
    {
        private static Dictionary<string, string> StrictTypeToType = new Dictionary<string, string>()
        {
            {"Int32", "int"},
            {"UInt32", "uint"},
            {"Void", "void"}
        };

        private static Dictionary<string, string> StrictTypeToName = new Dictionary<string, string>()
        {
            {"Int32", "Int"},
            {"UInt32", "Uint"}
        };

        private static string Translate(object o, Dictionary<string, string> d)
        {
            if (o == null)
                return null;
            var str = o.ToString();
            if (str == null)
                throw new InvalidOperationException();
            return d.TryGetValue(str, out var val) ? val : str;
        }

        private static string TranslateToType(object o) => Translate(o, StrictTypeToType);

        private static string TranslateToName(object o) => Translate(o, StrictTypeToName);

        protected override void GenerateBody()
        {
            var type = typeof(ISunVoxLib);
            if (!type.IsInterface)
                throw new Exception();

            var (delegateDefinitions, delegates, delegateCalls) = ReadData(type);

            AppendLine("using System;");
            AppendLine("using System.Reflection;");
            AppendLine();
            AppendLine("namespace SunSharp.LibraryLoading");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("public class ProxyClass : ISunVoxLib");
                AppendLine("{");
                AddIndent(() =>
                {
                    AddConstructor();
                    AppendLine();
                    AppendLine("#region delegate definitions");
                    AppendLine();
                    foreach (var d in delegateDefinitions)
                    {
                        AppendLine(d);
                        AppendLine();
                    }
                    AppendLine("#endregion delegate definitions");
                    AppendLine();
                    AppendLine("#region delegates");
                    AppendLine();
                    AppendLineNoTab("#pragma warning disable CS0649");
                    AppendLine();
                    foreach (var d in delegates)
                    {
                        AppendLine(d);
                        AppendLine();
                    }
                    AppendLineNoTab("#pragma warning restore CS0649");
                    AppendLine();
                    AppendLine("#endregion delegates");
                    AppendLine();
                    AppendLine($"#region interface");
                    AppendLine();
                    foreach (var d in delegateCalls)
                    {
                        AppendLine(d);
                        AppendLine();
                    }
                    AppendLine($"#endregion interface");
                });
                AppendLine("}");
            });
            AppendLine("}");
        }

        private void AddDelegateDefinitions()
        {
        }

        private void AddConstructor()
        {
            AppendLine("public ProxyClass(Func<string, Type, Delegate> GetDelegate)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("var type = GetType();");
                AppendLine("var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);");
                AppendLine("foreach (var field in fields)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("if (typeof(Delegate).IsAssignableFrom(field.FieldType))");
                    AppendLine("{");
                    AddIndent(() =>
                    {
                        AppendLine("field.SetValue(this, GetDelegate(field.Name, field.FieldType));");
                    });
                    AppendLine("}");
                });
                AppendLine("}");
            });
            AppendLine("}");
        }

        private static (ICollection<string> delegateDefinitions, ICollection<string> delegates, ICollection<string> delegateCalls) ReadData(Type t)
        {
            HashSet<string> delegateDefinitions = new();
            HashSet<string> delegates = new();
            HashSet<string> delegateCalls = new();
            foreach (var method in t.GetMethods())
            {
                (var delegateDefinition, var @delegate, var delegateCall) = ParseMethod(method);
                delegateDefinitions.Add(delegateDefinition);
                delegates.Add(@delegate);
                delegateCalls.Add(delegateCall);
            }

            return (delegateDefinitions.OrderBy(s => s).ToList(), delegates.OrderBy(s => s).ToList(), delegateCalls.OrderBy(s => s).ToList());
        }

        private static (string delegateDefinition, string @delegate, string delegateCall) ParseMethod(MethodInfo info)
        {
            string returnsTypeName = TranslateToType(info.ReturnType.Name) ?? "void";

            string delegateTypeName;
            {
                var pars = info.GetParameters();
                var returnsType = TranslateToName(info.ReturnType.Name) ?? "Void";
                var @out = returnsType.Length == 0 ? "Void" : returnsType;
                var @in = string.Join("_", pars.Select(s => TranslateToName(s.ParameterType.Name)));
                @in = @in.Length == 0 ? "Void" : @in;
                delegateTypeName = $"o_{@out}_i_{@in}";
            }

            string delegateTypeArgs;
            {
                var namedPars = new List<(Type, string)>();
                foreach (var parameter in info.GetParameters())
                {
                    int count = namedPars.Count(p => p.Item1 == parameter.ParameterType);
                    var parameterName = $"_{TranslateToType(parameter.ParameterType.Name)}{(count != 0 ? count : "")}"; // int, int2, int3...
                    namedPars.Add((parameter.ParameterType, parameterName));
                }
                delegateTypeArgs = string.Join(", ", namedPars.Select(p => $"{TranslateToType(p.Item1.Name)} {p.Item2}"));
            }

            string delegateInstanceName = $"{info.Name}";

            string delegateDefinition = $"private delegate {returnsTypeName} {delegateTypeName}({delegateTypeArgs});";
            string @delegate = $"private {delegateTypeName} {delegateInstanceName};";
            string delegateCall;
            // call
            {
                var pars = string.Join(", ", info.GetParameters().Select(p => $"{TranslateToType(p.ParameterType.Name)} {p.Name}"));
                var forwardedPars = string.Join(", ", info.GetParameters().Select(p => p.Name));
                delegateCall = $"{returnsTypeName} {info.DeclaringType?.Name}.{info.Name}({pars}) => {delegateInstanceName}({forwardedPars});";
            }

            return (delegateDefinition, @delegate, delegateCall);
        }
    }
}
