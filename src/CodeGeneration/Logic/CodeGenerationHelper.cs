using System.Collections.Frozen;

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

    internal static readonly FrozenDictionary<Type, string> TypeToCodeDictionary = new Dictionary<Type, string>
    {
        [typeof(int)] = "int",
        [typeof(uint)] = "uint",
        [typeof(float)] = "float",
        [typeof(double)] = "double",
        [typeof(void)] = "void",
        [typeof(string)] = "string",
        [typeof(bool)] = "bool",
        [typeof(byte)] = "byte",
        [typeof(ushort)] = "ushort",
        [typeof(short)] = "short",
        [typeof(long)] = "long",
        [typeof(ulong)] = "ulong",
    }.ToFrozenDictionary();

    public static string TypeToCode(Type type)
    {
        return TypeToCodeDictionary.TryGetValue(type, out var value)
            ? value
            : type.Name;
    }

    public static string GetTypeName(Type type, System.Reflection.NullabilityInfo? nullabilityInfo = null)
    {
        if (TypeToCodeDictionary.TryGetValue(type, out var typeName))
        {
            if (nullabilityInfo != null && !type.IsValueType &&
                nullabilityInfo.ReadState == System.Reflection.NullabilityState.Nullable)
            {
                return typeName + "?";
            }
            return typeName;
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return GetTypeName(underlyingType!) + "?";
        }

        if (type.IsArray)
        {
            var elementType = type.GetElementType();
            var elementNullability = nullabilityInfo?.ElementType;
            var arrayTypeName = GetTypeName(elementType!, elementNullability) + "[]";

            if (nullabilityInfo != null && nullabilityInfo.ReadState == System.Reflection.NullabilityState.Nullable)
            {
                return arrayTypeName + "?";
            }
            return arrayTypeName;
        }

        if (type.IsGenericType && type.Name.StartsWith("ValueTuple"))
        {
            var genericArgs = type.GetGenericArguments();
            var typeNames = string.Join(", ", genericArgs.Select(t => GetTypeName(t)));
            return $"({typeNames})";
        }

        var simpleName = type.Name;

        if (nullabilityInfo != null && !type.IsValueType &&
            nullabilityInfo.ReadState == System.Reflection.NullabilityState.Nullable)
        {
            return simpleName + "?";
        }

        return simpleName;
    }

    public static string FormatDefaultValue(object? defaultValue, Type parameterType)
    {
        if (defaultValue == null)
        {
            // For value types, null in reflection means 'default'
            if (parameterType.IsValueType)
            {
                return "default";
            }
            return "null";
        }

        if (parameterType.IsEnum)
        {
            return $"{parameterType.Name}.{defaultValue}";
        }

        if (defaultValue is string str)
        {
            return $"\"{str.Replace("\"", "\\\"")}\"";
        }

        if (defaultValue is bool b)
        {
            return b ? "true" : "false";
        }

        if (defaultValue is byte || defaultValue is sbyte ||
            defaultValue is short || defaultValue is ushort ||
            defaultValue is int || defaultValue is uint ||
            defaultValue is long || defaultValue is ulong)
        {
            return defaultValue.ToString()!;
        }

        if (defaultValue is float f)
        {
            return f.ToString(System.Globalization.CultureInfo.InvariantCulture) + "f";
        }

        if (defaultValue is double d)
        {
            return d.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        if (defaultValue is decimal dec)
        {
            return dec.ToString(System.Globalization.CultureInfo.InvariantCulture) + "m";
        }

        return defaultValue.ToString() ?? "default";
    }
}
