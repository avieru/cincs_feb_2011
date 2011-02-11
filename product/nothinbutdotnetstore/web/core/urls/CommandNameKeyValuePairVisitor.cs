using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.urls
{
    public class CommandNameKeyValuePairVisitor : UrlEncoder
    {
        public const string format_string = "{0}.cinc?";
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
            return string.Format(format_string, command_name);
        }
    }
}