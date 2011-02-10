using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class CommandNameKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        public string command_name { private set; get; }

        public void process(KeyValuePair<string, object> token)
        {
            process_first_item(token);
        }

        void process_first_item(KeyValuePair<string, object> token)
        {
            command_name = token.Value.ToString();
        }

        public string get_url()
        {
            return string.Format("{0}.cinc?", command_name);
        }
    }
}