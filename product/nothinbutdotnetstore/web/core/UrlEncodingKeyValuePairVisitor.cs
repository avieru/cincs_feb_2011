using System.Collections.Generic;
using System.Text;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class UrlEncodingKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        StringBuilder builder;
        bool has_processed_one_item;
        public string command_name { private set; get; }

        public UrlEncodingKeyValuePairVisitor(StringBuilder builder)
        {
            this.builder = builder;
        }

        public void process(KeyValuePair<string, object> token)
        {
            if (has_processed_one_item)
            {
                builder.AppendFormat("&{0}={1}", token.Key, token.Value);
                return;
            }
            process_first_item(token);
        }

        void process_first_item(KeyValuePair<string, object> token)
        {
            command_name = token.Value.ToString();
            has_processed_one_item = true;
        }

        public string get_url()
        {
            return string.Format("{0}?{1}", command_as_url(), builder);
        }

        string command_as_url()
        {
            return string.Format("{0}.cinc", command_name);
        }
    }
}