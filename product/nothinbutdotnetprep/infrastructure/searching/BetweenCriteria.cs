using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class BetweenCriteria<PropertyType> : Criteria<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly PropertyType value1;
        readonly PropertyType value2;

        public BetweenCriteria(PropertyType value1, PropertyType value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public bool is_satisfied_by(PropertyType value)
        {
            return value.CompareTo(value1) >= 0 && value.CompareTo(value2) <= 0;
        }
    }
}