using CodeGeneration.Generators;

namespace CodeGeneration.ReparsedData
{
    public class ModuleDesc
    {
        public string FriendlyName { get; set; }
        public string InternalName { get; set; }
        public string Description { get; set; }
        public ICollection<CtlDesc> Controllers { get; set; }
        public ICollection<CurveDesc> Curves { get; set; }
        public AddCodeDesc AdditionalCodeDescription { get; set; }

        public ModuleDesc(string friendlyName, string internalName, string description, ICollection<CtlDesc> controllers, ICollection<CurveDesc> curves, AddCodeDesc aditionalCodeDescription)
        {
            FriendlyName = friendlyName;
            InternalName = internalName;
            Description = description;
            Controllers = controllers;
            Curves = curves;
            AdditionalCodeDescription = aditionalCodeDescription;
        }
    }

    public class EnumDesc
    {
        public string Name { get; set; }
        public ICollection<(int value, string name)> Values { get; set; }

        public EnumDesc(string name, params (int, string)[] values)
        {
            Name = name;
            Values = values;
        }
    }

    public class CtlDesc
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public string InternalName { get; set; }
        public string Description { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool IgnoreInternalEnum { get; set; }
        public string EnumTypeName { get; set; }

        public CtlDesc(int id, string friendlyName, string internalName, string description, int min, int max, bool ignoreInternalEnum = false, string enumTypeName = null)
        {
            Id = id;
            FriendlyName = friendlyName;
            InternalName = internalName;
            Description = description;
            MinValue = min;
            MaxValue = max;
            EnumTypeName = enumTypeName;
            IgnoreInternalEnum = ignoreInternalEnum;
        }

        public CtlDesc(int id, string friendlyName, string internalname, string description, int min, int max, string enumTypeName)
        {
            Id = id;
            FriendlyName = friendlyName;
            InternalName = internalname;
            Description = description;
            MinValue = min;
            MaxValue = max;
            EnumTypeName = enumTypeName;
            IgnoreInternalEnum = false;
        }
    }

    public class CurveDesc
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public int Size { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public string Description { get; set; }

        public CurveDesc(int id, string friendlyName, string description, float min, float max, int size)
        {
            Id = id;
            FriendlyName = friendlyName;
            MinValue = min;
            MaxValue = max;
            Size = size;
            Description = description;
        }
    }

    public abstract class AddCodeDesc
    {
        public abstract void AddCode(CodeGenerationContext context, Data data = null);
    }

    public class AddCodeDesc<T> : AddCodeDesc where T : AdditionalGenerator, new()
    {
        public override void AddCode(CodeGenerationContext context, Data data = null)
        {
            var t = new T
            {
                Context = context,
                Data = data
            };
            t.AppendCode();
        }
    }
}
