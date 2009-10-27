using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class GreaterThan<PropertyType> : Criteria<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyType value_to_be_greater_than;

        public GreaterThan(PropertyType value_to_be_greater_than)
        {
            this.value_to_be_greater_than = value_to_be_greater_than;
        }

        public bool is_satisfied_by(PropertyType item)
        {
            return item.CompareTo(value_to_be_greater_than) > 0;
        }
    }
}