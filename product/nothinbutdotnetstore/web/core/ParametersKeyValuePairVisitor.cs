using System.Collections.Generic;
using System.Text;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class ParametersKeyValuePairVisitor : Visitor<KeyValuePair<string, object>>
    {
        IList<KeyValuePair<string, object>> parameters;
        bool first_item = true;

        public ParametersKeyValuePairVisitor(IList<KeyValuePair<string, object>> parameters)
        {
            this.parameters = parameters;
        }

        public void process(KeyValuePair<string, object> item)
        {
            if (first_item)
            {
                first_item = false;
                return;
            }

            parameters.Add(item);
        }

        public string get_query_string()
        {
            //TODO - Will deal with this later
            var builder = new StringBuilder();
            new List<KeyValuePair<string, object>>(parameters).ForEach(
                pair => { builder.AppendFormat("&{0}={1}", pair.Key, pair.Value.ToString()); });
            return builder.Remove(0, 1).ToString();
        }
    }
}