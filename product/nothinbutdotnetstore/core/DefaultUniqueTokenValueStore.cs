﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.core
{
    public class DefaultUniqueTokenValueStore : UniqueTokenValueStore
    {
        public IDictionary<string, object> tokens = new Dictionary<string, object>();

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return tokens.Select(pair => new KeyValuePair<string, object>(pair.Key, pair.Value)).GetEnumerator();
        }

        public void store_token_value(string token_key, object value)
        {
            if (token_exists_for(token_key)) return;

            tokens.Add(token_key, value);
        }

        bool token_exists_for(string token_key)
        {
            return tokens.ContainsKey(token_key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}