using System.Collections.Frozen;

namespace SunSharp.CodeGeneration.Logic;

public static class TypeTranslator
{
    private static readonly FrozenDictionary<Type, string> TypeToCodeDictionary = new Dictionary<Type, string>
    {
        [typeof(int)] = "int",
        [typeof(uint)] = "uint",
        [typeof(float)] = "float",
        [typeof(double)] = "double",
        [typeof(void)] = "void",
        [typeof(string)] = "string",
        [typeof(bool)] = "bool"
    }.ToFrozenDictionary();

    public static string TypeToCode(Type type)
    {
        return TypeToCodeDictionary.TryGetValue(type, out var value)
            ? value
            : type.Name;
    }
}
