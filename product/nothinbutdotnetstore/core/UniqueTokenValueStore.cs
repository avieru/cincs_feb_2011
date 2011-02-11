﻿using System.Collections.Generic;

namespace nothinbutdotnetstore.core
{
    public interface UniqueTokenValueStore : IEnumerable<KeyValuePair<string, object>>
    {
        void store_token_value(string token_key, object value);
    }
}