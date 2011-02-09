 using System.Collections.Specialized;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory,
                                            DefaultRequestFactory>
        {
        
        }

        [Subject(typeof(DefaultRequestFactory))]
        public class when_creating_new_request_based_on_query_string_of_departments  : concern
        {
            Establish c = () =>
            {
                query_string_collection = new NameValueCollection();

            };
            Because b = () =>
                sut.create_request_from(context);


            It should_return_specific_request = () =>
                request.ShouldBeAn<ViewDepartmentInDepartmentRequest>();

            static Request request;
            static object query_string_collection;
            static  context;
        }
    }
}
