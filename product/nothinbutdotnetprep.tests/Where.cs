using System;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.tests
{
    public class Where<ItemToFilter>
    {
        static public CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        static public void has_an<PropertyType>(Func<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            throw new NotImplementedException();
        }
    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => accessor(item).Equals(value));
        }

        public Predicate<ItemToFilter> equal_to_any(params PropertyType[] studios)
        {
            return new AnonymousCriteria<ItemToFilter>(item => Array.Exists<PropertyType>(studios, ccessor(item)));
        }
    }
}