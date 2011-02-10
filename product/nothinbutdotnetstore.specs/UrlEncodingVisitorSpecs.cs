using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class UrlEncodingVisitorSpecs
    {
        public abstract class concern : Observes<UrlEncoder,
                                            UrlEncodingVisitor>
        {
        }

        [Subject(typeof(UrlEncodingVisitor))]
        public class when_processing : concern
        {
            Establish c = () =>
            {
                base_encoder = the_dependency<UrlEncoder>();
                encoded_value = "sdfsddfsdfsdfsdf";
                token = new KeyValuePair<string, object>();
            };

            Because b = () =>
                sut.process(token);

            It should_tell_the_base_encoder_to_process_the_value = () =>
                base_encoder.received(x => x.process(token));

            static string encoded_value;
            static UrlEncoder base_encoder;
            static KeyValuePair<string, object> token;
        }

        public class when_getting_the_result : concern
        {
            Establish c = () =>
            {
                base_encoder = the_dependency<UrlEncoder>();
                original_value = "original";
                encoded_value = "sdfsddfsdfsdfsdf";

                base_encoder.Stub(x => x.get_result()).Return(original_value);
                provide_a_basic_sut_constructor_argument<UrlEncode>(x => encoded_value);
            };

            Because b = () =>
                result = sut.get_result();

            It should_html_encode_the_result_from_the_original = () =>
                result.ShouldEqual(encoded_value);


            static string encoded_value;
            static UrlEncoder base_encoder;
            static string result;
            static string original_value;
        }
        [Subject(typeof(UrlEncodingVisitor))]
        public class when_visiting : concern
        {
        }
    }
}