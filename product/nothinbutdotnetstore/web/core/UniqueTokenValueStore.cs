using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface UniqueTokenValueStore : IEnumerable<KeyValuePair<string,object>>
    {
        void store_token_value(string token_key,object value);
        bool is_already_in_the_store(string token_key);
    }
}