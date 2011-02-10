using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class UrlEncodingKeyValuePairVisitor
    {
        StringBuilder string_builder;

        public UrlEncodingKeyValuePairVisitor(StringBuilder string_builder)
        {
            this.string_builder = string_builder;
        }

        public void process(KeyValuePair<string, object> first_token)
        {
            string_builder.Append(string.Format("{0}.cinc", first_token.Value));
        }
    }
}