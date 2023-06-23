namespace SunSharp.DerivedData
{
    public class ControllerData : IDeepCopyable<ControllerData>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; }
        public ControllerType ControllerType { get; set; }

        public ControllerData DeepCopy()
        {
            var clone = new ControllerData
            {
                Id = this.Id,
                Name = this.Name,
                Value = this.Value,
                ControllerType = this.ControllerType
            };
            return clone;
        }
    }
}
