namespace nothinbutdotnetstore.core
{
    public class AndCriteria<T> : Criteria<T>
    {
        Criteria<T> first;
        Criteria<T> second;

        public AndCriteria(Criteria<T> first, Criteria<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool is_satisfied_by(T item)
        {
            return first.is_satisfied_by(item) && second.is_satisfied_by(item);
        }
    }
}