namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingCriteria<T> : Criteria<T>
    {
        Criteria<T> criteria;

        public NegatingCriteria(Criteria<T> criteria)
        {
            this.criteria = criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return ! criteria.is_satisfied_by(item);
        }
    }
}