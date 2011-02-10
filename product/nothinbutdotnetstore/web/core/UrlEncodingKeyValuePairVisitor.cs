using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class UrlEncodingKeyValuePairVisitor
    {
        public StringBuilder string_builder;

        public UrlEncodingKeyValuePairVisitor(StringBuil)
        public string command_name { private set; get; }

        public void process(KeyValuePair<string, object> first_token)
        {
            command_name = first_token.Value.ToString();
        }
    }
}