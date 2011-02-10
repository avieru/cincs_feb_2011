using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUniqueTokenValueStore : UniqueTokenValueStore
    {
        
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void store_token_value(string token_key, object value)
        {
            throw new NotImplementedException();
        }

        public bool is_already_in_the_store(string token_key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}