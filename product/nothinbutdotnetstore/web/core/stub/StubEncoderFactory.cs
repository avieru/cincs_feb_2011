using System;
using System.Collections.Generic;
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

        private class IsNotFirst : Criteria<KeyValuePair<string, object>>
        {
            int number_processed;

            public bool is_satisfied_by(KeyValuePair<string, object> item)
            {
                return number_processed++ > 0;
            }
        }

        private class MixedEncoder : UrlEncoder
        {
            ChainedVisitor<KeyValuePair<string, object>> composite_encoder;
            CommandNameKeyValuePairVisitor name_encoder;
            ParametersKeyValuePairVisitor params_encoder;

            public MixedEncoder()
            {
                this.name_encoder = new CommandNameKeyValuePairVisitor();
                this.params_encoder = new ParametersKeyValuePairVisitor(new List<KeyValuePair<string, object>>());
                composite_encoder = new ChainedVisitor<KeyValuePair<string,object>>(
                    new ConditionalVisitor<KeyValuePair<string,object>>(name_encoder,
                        new IsFirstItem<KeyValuePair<string,object>>()), 
                        new ConditionalVisitor<KeyValuePair<string,object>>(params_encoder,
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