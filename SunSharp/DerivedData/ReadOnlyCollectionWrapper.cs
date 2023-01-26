using System.Collections;
using System.Collections.Generic;

namespace SunSharp.DerivedData
{
    public class ReadOnlyCollectionWrapper<T> : IReadOnlyCollection<T>
    {
        private ICollection<T> _collection;

        public ReadOnlyCollectionWrapper(ICollection<T> collection)
        {
            _collection = collection;
        }

        public int Count => _collection.Count;

        public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _collection.GetEnumerator();
    }

    public static class ReadOnlyCollectionWrapperExtensions
    {
        public static IReadOnlyCollection<T> AsReadonlyOrGetWrapper<T>(this ICollection<T> collection)
        {
            if (collection is IReadOnlyCollection<T> _collection)
                return _collection;
            return new ReadOnlyCollectionWrapper<T>(collection);
        }
    }
}
