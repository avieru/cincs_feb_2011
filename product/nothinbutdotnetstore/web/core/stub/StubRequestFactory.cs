using System;
using System.Web;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
            return new StubRequest(the_current_context);
        }

        class StubRequest : Request
        {
            HttpContext the_current_context;

            public StubRequest(HttpContext the_current_context)
            {
                this.the_current_context = the_current_context;
            }

            public InputModel map<InputModel>()
            {
                var item = new Department();
                item.number_of_products = 2;
                int number = get_the_number_of_products_in(the_current_context);
                item.number_of_products = number;
                object result = item;

                return (InputModel) result;
            }

            int get_the_number_of_products_in(HttpContext http_context)
            {
                return int.Parse(the_current_context.Request.QueryString[new DefaultExpressionToPropertyNameMapper()
                                                                             .map<Department, int>(
                                                                                 x => x.number_of_products)]);
            }

            public string raw_url
            {
                get { return the_current_context.Request.RawUrl;}
            }
        }
    }
}