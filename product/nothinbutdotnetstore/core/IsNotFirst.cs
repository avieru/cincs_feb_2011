using System.Collections.Generic;

namespace nothinbutdotnetstore.core
{
    public class IsNotFirst : Criteria<KeyValuePair<string, object>>
    {
        int number_processed;

        public bool is_satisfied_by(KeyValuePair<string, object> item)
        {
            return number_processed++ > 0;
        }
    }
}