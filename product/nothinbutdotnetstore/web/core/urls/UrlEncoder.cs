using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public interface UrlEncoder : ValueReturningVisitior<KeyValuePair<string, object>,string >
    {
        
    }
}