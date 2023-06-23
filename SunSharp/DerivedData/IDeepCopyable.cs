namespace SunSharp.DerivedData
{
    public interface IDeepCopyable<out T>
    {
        T DeepCopy();
    }
}
