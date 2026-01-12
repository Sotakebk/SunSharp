using System.Collections.Immutable;
using System.Text.RegularExpressions;
using CodeGeneration;

namespace SunSharp.CodeGeneration.Logic;

public sealed record ParsedFunction(string ReturnType, string Name, ParsedParameter[] Parameters, string OriginalPrototype, Type CSharpReturnType);

public sealed record ParsedParameter(string CType, string Name, Type CSharpType);

public sealed record ParsedHeader(ParsedFunction[] Functions);

public static partial class SunVoxHeaderParser
{
    public static ParsedHeader Parse()
    {
        var headerPath = PathHelper.GetProjectFilePath("SunSharp/Native/sunvox.h");
        if (!File.Exists(headerPath))
        {
            throw new FileNotFoundException("Could not locate sunvox.h", headerPath);
        }
        var lines = File.ReadAllLines(headerPath);
        var functions = ParseFunctions(lines);
        return new ParsedHeader(functions);
    }

    private static ParsedFunction[] ParseFunctions(string[] lines)
    {
        var functions = new List<ParsedFunction>();
        var (start, end) = FindStaticSection(lines);
        var rx = FunctionParsingRegex();

        for (var i = start; i < end; i++)
        {
            var m = rx.Match(lines[i]);
            if (!m.Success)
            {
                continue;
            }

            var ret = NormalizeType(m.Groups["ret"].Value.Trim());
            var name = m.Groups["name"].Value.Trim();
            var argsRaw = m.Groups["args"].Value.Trim();
            var original = lines[i].Replace("SUNVOX_FN_ATTR", string.Empty).Trim();

            var parameters = new List<ParsedParameter>();

            if (argsRaw is not ("void" or ""))
            {
                foreach (var arg in argsRaw.Split(','))
                {
                    var ap = arg.Trim();
                    if (ap.Length == 0) continue;
                    var (cType, parameterName) = ParseParameter(ap);
                    cType = NormalizeType(cType);
                    parameters.Add(new ParsedParameter(cType, parameterName, MapCTypeToCSharp(cType)));
                }
            }
            functions.Add(new ParsedFunction(ret, name, parameters.ToArray(), original, MapCTypeToCSharp(ret)));
        }

        if (functions.Any(f => f.CSharpReturnType == null))
        {
            throw new InvalidOperationException("One or more functions could not have their return type mapped to C#.");
        }

        if (functions.Count == 0)
        {
            throw new Exception("No functions were parsed from the SUNVOX_STATIC_LIB section of the header.");
        }

        return [.. functions];
    }

    private static (int start, int end) FindStaticSection(string[] lines)
    {
        int start = -1, end = -1;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#ifdef SUNVOX_STATIC_LIB"))
            {
                start = i + 1;
            }
        }

        if (start == -1)
        {
            throw new Exception("Could not find start of SUNVOX_STATIC_LIB section in sunvox.h.");
        }

        for (int i = start; i < lines.Length; i++)
        {
            if (lines[i].Contains("/* ... SUNVOX_STATIC_LIB */"))
            {
                end = i;
                break;
            }
        }

        if (end == -1)
        {
            throw new Exception("Could not find end of SUNVOX_STATIC_LIB section in sunvox.h.");
        }

        return (start, end);
    }

    private static (string CType, string Name) ParseParameter(string param)
    {
        var parts = param.Split([' '], StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 1) return (parts[0], string.Empty);
        var name = parts[^1];
        var type = string.Join(" ", parts.Take(parts.Length - 1));
        return (type, name);
    }

    private static string NormalizeType(string t)
    {
        t = t.Replace("  ", " ").Trim();
        t = t.Replace(" *", "*").Replace("* ", "*");
        return t;
    }

    private static readonly ImmutableDictionary<string, Type> SimpleTypeMap = new Dictionary<string, Type>
    {
        { "int", typeof(int) },
        { "uint32_t", typeof(uint) },
        { "const char*", typeof(IntPtr) },
        { "char*", typeof(IntPtr) },
        { "void*", typeof(IntPtr) },
        { "sunvox_note*", typeof(IntPtr) },
        { "int16_t*", typeof(IntPtr) },
        { "float*", typeof(IntPtr) },
        { "int*", typeof(IntPtr) },
        { "uint32_t*", typeof(IntPtr) },
        { "void", typeof(void) }
    }.ToImmutableDictionary();

    private static Type MapCTypeToCSharp(string cType)
    {
        if (SimpleTypeMap.TryGetValue(cType, out var mapped)) return mapped;

        throw new ArgumentException($"Unexpected C-lang type: '{cType}'.", nameof(cType));
    }

    [GeneratedRegex(@"^\s*(?<ret>(?:const\s+)?[a-zA-Z_][a-zA-Z0-9_]*\s*(?:\*)?)\s+(?<name>sv_[a-z0-9_]+)\s*\((?<args>[^)]*)\)\s*(?:SUNVOX_FN_ATTR)?\s*;", RegexOptions.Compiled)]
    private static partial Regex FunctionParsingRegex();
}
