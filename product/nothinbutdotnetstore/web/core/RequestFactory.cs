using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        Request create_request_from(HttpContext the_current_context);
    }

    public class DefaultRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
            throw new NotImplementedException();
        }
    }
}