 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{   
    public class UrlEncoderVisitorSpecs
    {
        public abstract class concern : Observes<UrlEncoder,
                                            DefaultUrlEncoder>
        {
        
        }

        [Subject(typeof(DefaultUrlEncoder))]
        public class when_getting_results : concern
        {
            Establish c = () =>
            {
                supporting_visitor = an<MixedEncoder>();
                provide_a_basic_sut_constructor_argument(supporting_visitor);
            };

            Because b = () =>
                result = sut.get_result();


            It should_return_encoded_results = () =>
                result.ShouldEqual(encoded_url_string);

            static string result;
            static string encoded_url_string;
            static MixedEncoder supporting_visitor;
        }
    }

    public class DefaultUrlEncoder : UrlEncoder
    {
        readonly UrlEncoder encoder;

        public DefaultUrlEncoder(UrlEncoder encoder)
        {
            this.encoder = encoder;
        }

        public void process(KeyValuePair<string, object> item)
        {
            encoder.process(item);
        }

        public string get_result()
        {
            return mechanically_encode_this_in_some_way(encoder.get_result());
        }

        string mechanically_encode_this_in_some_way(string results)
        {
            throw new NotImplementedException();
        }
    }

    class MixedEncoder : UrlEncoder
    {
        ChainedVisitor<KeyValuePair<string, object>> composite_encoder;
        CommandNameKeyValuePairVisitor name_encoder;
        ParametersKeyValuePairVisitor params_encoder;

        public MixedEncoder()
        {
            this.name_encoder = new CommandNameKeyValuePairVisitor();
            this.params_encoder = new ParametersKeyValuePairVisitor(new List<KeyValuePair<string, object>>());
            composite_encoder = new ChainedVisitor<KeyValuePair<string, object>>(
                new ConditionalVisitor<KeyValuePair<string, object>>(name_encoder,
                    new IsFirstItem<KeyValuePair<string, object>>()),
                    new ConditionalVisitor<KeyValuePair<string, object>>(params_encoder,
                        new IsNotFirst()));
        }

        public void process(KeyValuePair<string, object> item)
        {
            composite_encoder.process(item);
        }

        public string get_result()
        {
            return string.Format("{0}{1}", name_encoder.get_result(),
                                 params_encoder.get_result());
        }
    }

}
