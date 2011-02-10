using System;
using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class ParametersKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        IList<KeyValuePair<string, object>> parameters;

        public ParametersKeyValuePairVisitor(IList<KeyValuePair<string, object>> parameters)
        {
            this.parameters = parameters;
        }

        public void process(KeyValuePair<string, object> item)
        {
            if (first_item()) return;

            parameters.Add(item);
        }

        bool first_item()
        {
            return parameters.Count == 0;
        }

        public string get_query_string()
        {
            throw new NotImplementedException();
        }
    }
}