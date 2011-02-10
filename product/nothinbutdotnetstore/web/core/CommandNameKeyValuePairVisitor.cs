using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class CommandNameKeyValuePairVisitor : ValueReturningVisitior<KeyValuePair<string, object>,string>
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

        public string get_result()
        {
            return string.Format("{0}.cinc?", command_name);
        }
    }
}