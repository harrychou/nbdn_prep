using System;

namespace nothinbutdotnetprep.ranges
{
    public interface Range<T> where T : IComparable<T>
    {
        bool contains(T item);
    }
}