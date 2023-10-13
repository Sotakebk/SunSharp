namespace SunSharp.Data
{
    public class ControllerData : IDeepCopyable<ControllerData>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; }
        public int Offset { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Group { get; set; }
        public ControllerType ControllerType { get; set; }

        public ControllerData DeepCopy()
        {
            var clone = new ControllerData
            {
                Id = Id,
                Name = Name,
                Value = Value,
                MinValue = MinValue,
                MaxValue = MaxValue,
                Offset = Offset,
                Group = Group,
                ControllerType = ControllerType
            };
            return clone;
        }
    }
}
