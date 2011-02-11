using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.urls
{
    public class UrlEncodingVisitor : UrlEncoder
    {
        UrlEncoder base_encoder;
        UrlEncode encode;

        public UrlEncodingVisitor(UrlEncoder base_encoder, UrlEncode encode)
        {
            this.base_encoder = base_encoder;
            this.encode = encode;
        }

        public string get_result()
        {
            return encode(base_encoder.get_result());
        }

        public void process(KeyValuePair<string, object> item)
        {
            base_encoder.process(item);
        }
    }
}