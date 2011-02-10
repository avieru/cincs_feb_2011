 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ConditionalVisitorSpecs
    {
        public abstract class concern : Observes<Visitor<int>,
                                            ConditionalVisitor<int>>
        {
        
        }

        [Subject(typeof(ConditionalVisitor<>))]
        public class when_processing_an_item_and_its_specification_is_satisfied : concern
        {
            Establish c = () =>
            {
                real_visitor = the_dependency<Visitor<int>>();
                item = 2;

                condition = the_dependency<Criteria<int>>();

                condition.Stub(x => x.is_satisfied_by(item)).Return(true);
            };

            Because b = () =>
                sut.process(item);


            It should_tell_the_real_visitor_to_process_the_item = () =>
                real_visitor.process(item);

            static Visitor<int> real_visitor;
            static int item;
            static Criteria<int> condition;
        }
    }
}
