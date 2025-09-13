using System.Collections.Generic;
using System.Collections.Immutable;

namespace SunSharp.CodeGeneration.NativeProxy;

public class TypeNameTranslation
{
    private static readonly ImmutableDictionary<string, string> StrictTypeNameToFriendlyTypeNameDictionary =
        new Dictionary<string, string>
        {
            { "Int32", "int" },
            { "UInt32", "uint" },
            { "Void", "void" }
        }.ToImmutableDictionary();

    private static readonly ImmutableDictionary<string, string> StrictTypeNameToCapitalizedName =
        new Dictionary<string, string>
        {
            { "Int32", "Int" },
            { "UInt32", "Uint" }
        }.ToImmutableDictionary();

    public static string TranslateToFriendlyName(Type type)
    {
        return Translate(type, StrictTypeNameToFriendlyTypeNameDictionary);
    }

    public static string TranslateToCapitalizedName(Type type)
    {
        return Translate(type, StrictTypeNameToCapitalizedName);
    }

    public static string Translate(Type type, ImmutableDictionary<string, string> d)
    {
        var str = type.Name;
        return d.GetValueOrDefault(str, str);
    }
}
