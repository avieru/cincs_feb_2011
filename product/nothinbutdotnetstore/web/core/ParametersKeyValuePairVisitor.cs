using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class ParametersKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        bool first_processed = false;

        void process(KeyValuePair<string, object> token)
        {
            
        }
    }
}