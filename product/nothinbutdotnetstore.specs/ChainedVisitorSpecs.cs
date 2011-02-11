 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.specs
{   
    public class ChainedVisitorSpecs
    {
        public abstract class concern : Observes<Visitor<int>,
                                            ChainedVisitor<int>>
        {
        
        }

        [Subject(typeof(ChainedVisitor<>))]
        public class when_processing_an_item : concern
        {
            Establish c = () =>
            {
                first = an<Visitor<int>>();
                second = an<Visitor<int>>();

                create_sut_using(() => new ChainedVisitor<int>(first,second));
            };

            Because b = () =>
                sut.process(2);


            It should_delegate_processing_to_both_visitors = () =>
            {
                first.received(x => x.process(2));
                second.received(x => x.process(2));
            };

            static Visitor<int> first;
            static Visitor<int> second;
        }
    }
}
