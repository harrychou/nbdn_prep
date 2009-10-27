using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class FuncExtensions
    {
        static public Criteria<T> equal_to<T, PropertyValue>(this Func<T, PropertyValue> accessor, PropertyValue value)
        {
            return new AnonymousCriteria<T>(obj => accessor(obj).Equals(value));
        }
    }
}