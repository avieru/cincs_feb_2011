using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class UrlEncodingKeyValuePairVisitor
    {
        StringBuilder builder;
        public string command_name { private set; get; }

        public UrlEncodingKeyValuePairVisitor(StringBuilder builder)
        {
            this.builder = builder;
        }

        public void process(KeyValuePair<string, object> token)
        {
            if (command_name == null)
            {
                command_name = token.Value.ToString();
                return;
            }
            builder.AppendFormat("&{0}={1}", token.Key, token.Value);
        }

        public string get_url()
        {
            return string.Format("{0}?{1}",command_as_url(),builder);
        }

        string command_as_url()
        {
            return string.Format("{0}.cinc", command_name);
        }
    }
}