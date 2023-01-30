namespace CodeGeneration
{
    public class ModuleDescription
    {
        public string Name { get; set; }
        public string InternalName { get; set; }
        public string Description { get; set; }
        public ICollection<ControllerDescription> Controllers { get; set; }
        public ICollection<CurveDescription> Curves { get; set; }

        public ModuleDescription(string name, string internalName, string description, ICollection<ControllerDescription> controllers, ICollection<CurveDescription> curves)
        {
            Name = name;
            InternalName = internalName;
            Description = description;
            Controllers = controllers;
            Curves = curves;
        }
    }

    public class EnumDescription
    {
        public string Name { get; set; }
        public ICollection<(int value, string name)> Values { get; set; }

        public EnumDescription(string name, params (int, string)[] values)
        {
            Name = name;
            Values = values;
        }
    }

    public class ControllerDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string EnumTypeName { get; set; }

        public ControllerDescription(int id, string name, string originalName, string description, int min, int max, string enumTypeName = null)
        {
            Id = id;
            Name = name;
            OriginalName = originalName;
            Description = description;
            MinValue = min;
            MaxValue = max;
            EnumTypeName = enumTypeName;
        }
    }

    public class CurveDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public string Description { get; set; }

        public CurveDescription(int id, string name, string description, float min, float max, int size)
        {
            Id = id;
            Name = name;
            MinValue = min;
            MaxValue = max;
            Size = size;
            Description = description;
        }
    }
}
