namespace nothinbutdotnetstore.core
{
    public class ChainedVisitor<ItemToVisit> : Visitor<ItemToVisit>
    {
        Visitor<ItemToVisit> first;
        Visitor<ItemToVisit> second;

        public ChainedVisitor(Visitor<ItemToVisit> first, Visitor<ItemToVisit> second)
        {
            this.first = first;
            this.second = second;
        }

        public void process(ItemToVisit item)
        {
            first.process(item);
            second.process(item);
        }
    }
}