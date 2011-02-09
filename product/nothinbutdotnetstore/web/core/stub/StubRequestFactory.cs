using System.Web;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
         
        }

        class StubRequest : Request
        {
        }
    }
}