using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class GreaterThanCriteria<PropertyType> : Criteria<PropertyType> where PropertyType : IComparable<PropertyType> 
    {
        PropertyType value_to_be_greater_than;
        public GreaterThanCriteria(PropertyType value)
        {
            value_to_be_greater_than = value;
        }

        public bool is_satisfied_by(PropertyType item)
        {
            return item.CompareTo(value_to_be_greater_than) > 0;
        }
    }
}