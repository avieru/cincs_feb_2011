using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

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
                departments = the_dependency<Departments>();
                the_main_departments = new List<Department> {new Department()};

                renderer = the_dependency<Renderer>();
                request = an<Request>();

                departments.Stub(x => x.get_the_main_departments()).Return(the_main_departments);

            };

            Because b = () =>
                sut.run(request);

            It should_send_departments_to_renderer = () =>
                renderer.received(x => x.render(the_main_departments));

            static Departments departments;
            static Request request;
            static Renderer renderer;
            static IEnumerable<Department> the_main_departments;
        }
    }
}