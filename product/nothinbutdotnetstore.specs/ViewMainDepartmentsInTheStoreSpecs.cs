using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application;
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

        [Subject(typeof(ViewMainDepartmentsInTheStoreSpecs))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                repository = the_dependency<Repository>();
                list_of_departments = new List<Department>();
                repository.Stub(x => x.get_departments()).Return(list_of_departments);
                view_renderer = the_dependency<ViewRenderer>();
            };

            Because b = () =>
                sut.run(request);

            It should_call_repository_to_get_departments = () =>
            {
            };

            It should_get_a_list_of_departments = () =>
                list_of_departments.ShouldBeEmpty();

            It should_send_renderer_the_data = () =>
                view_renderer.received(x => x.render_view_with(list_of_departments, request));
                

            static Request request;
            static Repository repository;
            static IList<Department> list_of_departments;
            static ViewRenderer view_renderer;
        }
    }
}