namespace ManualJobs
{
    public abstract class ManualTestContainer
    {
        public string Name { get; protected set; }

        public ManualTestContainer(string name)
        {
            Name = name;
        }

        public abstract void Run();
    }

    public class ManualJobContainer<T> : ManualTestContainer
        where T : BaseManualTest, new()
    {
        public ManualJobContainer(string name) : base(name)
        {
        }

        public override void Run()
        {
            var instance = new T();
            instance.Run();
        }
    }
}
