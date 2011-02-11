using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubEncoderFactory
    {
        public UrlEncoder build()
        {
            return new MixedEncoder();
        }

        class IsNotFirst : Criteria<KeyValuePair<string, object>>
        {
            int number_processed;

            public bool is_satisfied_by(KeyValuePair<string, object> item)
            {
                return number_processed++ > 0;
            }
        }

        class MixedEncoder : UrlEncoder
        {
            ChainedVisitor<KeyValuePair<string, object>> composite_encoder;
            UrlEncoder name_encoder;
            UrlEncoder params_encoder;

            public MixedEncoder()
            {
                this.name_encoder = new UrlEncodingVisitor(new CommandNameKeyValuePairVisitor(), HttpUtility.UrlEncode);
                this.params_encoder =
                    new UrlEncodingVisitor(new ParametersKeyValuePairVisitor(new List<KeyValuePair<string, object>>()),
                                    HttpUtility.UrlEncode);

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
}