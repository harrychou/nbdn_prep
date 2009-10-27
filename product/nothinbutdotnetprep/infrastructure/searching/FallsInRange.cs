using System;
using nothinbutdotnetprep.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class FallsInRange<T> : Criteria<T> where T : IComparable<T>
    {
        Range<T> range;

        public FallsInRange(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}