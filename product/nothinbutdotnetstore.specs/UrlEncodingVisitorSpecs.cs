using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core.urls;
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
                items_encoded = new List<object>();
                token = new KeyValuePair<string, object>("the key", "23434");
                provide_a_basic_sut_constructor_argument<UrlEncode>(x =>
                {
                    items_encoded.Add(x);
                    return encoded_value;
                });
            };

            Because b = () =>
                sut.process(token);

            It should_encode_the_key_and_value = () =>
                items_encoded.Count.ShouldEqual(2);

            It should_pass_a_newly_encoded_key_value_pair_to_the_base_encoder = () =>
                base_encoder.received(x => x.process(Arg<KeyValuePair<string, object>>.Is.NotEqual(token)));
  


            static string encoded_value;
            static UrlEncoder base_encoder;
            static KeyValuePair<string, object> token;
            static List<object> items_encoded;
        }

        public class when_getting_the_result : concern
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument<UrlEncode>(x => "not used in this test");
                base_encoder = the_dependency<UrlEncoder>();
                original_value = "original";

                base_encoder.Stub(x => x.get_result()).Return(original_value);
            };

            Because b = () =>
                result = sut.get_result();

            It should_get_the_raw_result_from_the_base_encoder = () =>
                result.ShouldEqual(original_value);

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