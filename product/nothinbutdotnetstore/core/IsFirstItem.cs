namespace nothinbutdotnetstore.core
{
    public class IsFirstItem<T> : Criteria<T>
    {
        int invocations;

        public bool is_satisfied_by(T item)
        {
            return invocations++ == 0;
        }
    }
}