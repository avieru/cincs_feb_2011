using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class UrlEncodingKeyValuePairVisitor
    {
        public string command_name { private set; get; }


        public void process(KeyValuePair<string, object> first_token)
        {
            command_name = first_token.Value.ToString();
        }

        public string get_url()
        {
            throw new NotImplementedException();
        }
    }
}