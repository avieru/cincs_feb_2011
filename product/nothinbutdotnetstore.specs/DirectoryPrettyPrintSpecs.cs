using System.IO; 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{
    public class DirectoryPrettyPrintSpecs
    {
        public abstract class concern : Observes<PrettyPrinter>
        {
            Establish c = () =>
            {
                out_writer = the_dependency<TextWriter>();
                provide_a_basic_sut_constructor_argument(out_writer);
            };

            static TextWriter out_writer;
        }

        public class when_listing_directory : concern
        {
        }
    }
}
