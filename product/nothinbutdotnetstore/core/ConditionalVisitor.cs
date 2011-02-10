namespace nothinbutdotnetstore.core
{
    public class ConditionalVisitor<ItemToVisit> : Visitor<ItemToVisit>
    {
        Visitor<ItemToVisit> real_visitor;
        Criteria<ItemToVisit> criteria;

        public ConditionalVisitor(Visitor<ItemToVisit> real_visitor, Criteria<ItemToVisit> criteria)
        {
            this.real_visitor = real_visitor;
            this.criteria = criteria;
        }

        public void process(ItemToVisit item)
        {
            if (criteria.is_satisfied_by(item)) real_visitor.process(item);
        }
    }
}