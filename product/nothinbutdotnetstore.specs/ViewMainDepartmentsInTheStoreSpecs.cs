using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                department_store = an<DepartmentStore>();
                request = an<Request>();
                renderer = an<Renderer>();
            };

            Because b = () =>
                sut.run(request);


            It should_request_departments_from_department_store = () =>
                department_store.received(x => x.get_departments());

            It should_send_departments_to_renderer = () =>
                renderer.received(x => x.render());

            static DepartmentStore department_store;
            static Request request;
            static Renderer renderer;
        }
    }
}