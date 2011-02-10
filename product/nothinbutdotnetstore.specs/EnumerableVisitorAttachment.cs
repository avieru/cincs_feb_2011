 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{   
    public class EnumerableVisitorAttachmentSpecs
    {
        public abstract class concern : Observes<IEnumerable<object>>
        {
        
        }

        [Subject(typeof(EnumerableVisitorAttachment))]
        public class when_calling_this_extension_method : concern
        {
            Establish c = () =>
            {
                the_enumerable = an<IEnumerable<object>>();
                the_process_delegate = an<ProcessDelegate<object>>();
            };

            Because b = () =>
                sut.visit(the_process_delegate);


            It should_attach_the_visitor_to_enumerable = () =>
                

            static IEnumerable<object> the_enumerable;
            static ProcessDelegate<object> the_process_delegate;
        }
    }

    public delegate void ProcessDelegate<Item>(Item item);

    public static class EnumerableVisitorAttachment
    {
        public static void visit(this IEnumerable<object> enumerable,ProcessDelegate<object> process_delegate)
        {
            
        }
    }
}
