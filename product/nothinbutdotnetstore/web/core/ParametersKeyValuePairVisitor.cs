using System.Collections.Generic;
using System.Text;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class ParametersKeyValuePairVisitor : ValueReturningVisitior<KeyValuePair<string, object>,string>
    {
        IList<KeyValuePair<string, object>> parameters;

        public ParametersKeyValuePairVisitor(IList<KeyValuePair<string, object>> parameters)
        {
            this.parameters = parameters;
        }

        public void process(KeyValuePair<string, object> item)
        {
            parameters.Add(item);
        }

        public string get_result()
        {

            //TODO - Will deal with this later
            var builder = new StringBuilder();
            new List<KeyValuePair<string, object>>(parameters).ForEach(
                pair => { builder.AppendFormat("&{0}={1}", pair.Key, pair.Value.ToString()); });
            return builder.Remove(0, 1).ToString();
        }
    }
}