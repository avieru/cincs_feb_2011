 using System.Collections.Generic;
 using System.Text;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs
{   
    public class UrlEncodingKeyValuePairVisitorSpecs
    {
        public abstract class concern : Observes<UrlEncodingKeyValuePairVisitor>
        {
        
        }

        [Subject(typeof(UrlEncodingKeyValuePairVisitor))]
        public class when_processing_the_first_key_value_pair : concern
        {

            Establish c = () =>
            {
                command_name = "our_command";
                builder = new StringBuilder();
                first_token = new KeyValuePair<string, object>("command_name",command_name);
                provide_a_basic_sut_constructor_argument(builder);
            };

            Because b = () =>
                sut.process(first_token);

            It should_append_the_name_of_the_command_to_the_builder_with_the_appropriate_handler_suffix = () =>
                builder.ToString().ShouldBeEqualIgnoringCase("{0}.cinc".format_using(command_name));

            static StringBuilder builder;
            static KeyValuePair<string,object> first_token;
            static string command_name;
        }
    }

}
