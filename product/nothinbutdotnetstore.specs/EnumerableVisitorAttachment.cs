 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class EnumerableExtensionsSpecs
    {
        public abstract class concern : Observes
        {
        
        }

        public class Person
        {
            public int age { get; set; }
        }
        public class when_visiting_each_item_in_an_enumerable_for_a_result : concern
        {
            Establish c = () =>
            {

                visitor = an<ValueReturningVisitior<int,int>>();
                the_enumerable = an<IEnumerable<object>>();
                items = Enumerable.Range(1, 100);

                visitor.Stub(x => x.get_result()).Return(23);

            };

            Because b = () =>
                result = EnumerableExtensions.get_result_of_visit_all_items_with(items, visitor);


            It should_tell_the_visitor_to_process_each_item = () =>
                items.each(x => visitor.received(y => y.process(x)));

            It should_return_the_result_from_the_visitor = () =>
                result.ShouldEqual(23);
                

            static IEnumerable<object> the_enumerable;
            static ValueReturningVisitior<int, int> visitor;
            static IEnumerable<int> items;
            static int result;
        }
        [Subject(typeof(EnumerableExtensions))]
        public class when_visiting_each_item_in_an_enumerable : concern
        {
            Establish c = () =>
            {
                visitor = an<Visitor<int>>();
                the_enumerable = an<IEnumerable<object>>();
                items = Enumerable.Range(1, 100);
            };

            Because b = () =>
                EnumerableExtensions.visit_all_items_with(items, visitor);


            It should_tell_the_visitor_to_process_each_item = () =>
                items.each(x => visitor.received(y => y.process(x)));
                

            static IEnumerable<object> the_enumerable;
            static Visitor<int> visitor;
            static IEnumerable<int> items;
        }
        public class when_processing_each_item_in_an_enumerable_with_an_action : concern
        {
            Establish c = () =>
            {
                number_of_times_invoked = 0;
                the_enumerable = an<IEnumerable<object>>();
                items = Enumerable.Range(1, 100);
            };

            Because b = () =>
                EnumerableExtensions.for_each(items, x =>
                {
                    number_of_times_invoked++;
                }
                );

            It should_invoke_the_action_against_each_item = () =>
                number_of_times_invoked.ShouldEqual(items.Count());
                

            static IEnumerable<object> the_enumerable;
            static IEnumerable<int> items;
            static int number_of_times_invoked;
        }
    }


}
