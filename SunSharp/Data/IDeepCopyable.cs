namespace SunSharp.Data
{
    public interface IDeepCopyable<out T>
    {
        T DeepCopy();
    }
}
