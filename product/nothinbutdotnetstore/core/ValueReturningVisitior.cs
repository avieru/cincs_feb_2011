namespace nothinbutdotnetstore.core
{
    public interface ValueReturningVisitior<ItemToVisit, ReturnType> : Visitor<ItemToVisit>
    {
        ReturnType get_result();
    }
}