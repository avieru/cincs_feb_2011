using System;
using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;
            }
        }
    }
}