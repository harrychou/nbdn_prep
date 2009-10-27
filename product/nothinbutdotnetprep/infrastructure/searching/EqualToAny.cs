using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualToAny<T> : Criteria<T>
    {
        IEnumerable<T> values;

        public EqualToAny(IEnumerable<T> values)
        {
            this.values = values;
        }

        public bool is_satisfied_by(T item)
        {
            return Array.Exists(values.ToArray(),value => value.Equals(item));
        }
    }
}