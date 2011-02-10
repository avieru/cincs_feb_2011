using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class CommandNameKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        bool has_processed_one_item;
        public string command_name { private set; get; }

        public void process(KeyValuePair<string, object> token)
        {
            if (has_processed_one_item) return;

            process_first_item(token);
        }

        void process_first_item(KeyValuePair<string, object> token)
        {
            command_name = token.Value.ToString();
            has_processed_one_item = true;
        }

        public string get_url()
        {
            return string.Format("{0}.cinc?", command_name);
        }
    }
}