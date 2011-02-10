using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlEncoder : ValueReturningVisitior<KeyValuePair<string, object>,string >
    {
        
    }
}