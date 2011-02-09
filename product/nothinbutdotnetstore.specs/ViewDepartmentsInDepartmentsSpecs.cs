 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewDepartmentsInDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentsInDepartments>
        {
        
        }

        [Subject(typeof(ViewDepartmentsInDepartments))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<ViewDepartmentInDepartmentRequest>();
                renderer = the_dependency<Renderer>();
                deparments = the_dependency<Departments>();
                
                list_of_departments_in_department = new List<Department>();
                deparments.Stub(x => x.get_sub_departments_for(department));
            };


            Because b = () =>
                sut.run(request);

            It should_ask_request_for_department_info = () =>
                request.received(x => x.get_department_info());

            It should_send_departments_to_renderer = () =>
                renderer.render(list_of_departments_in_department);

            static Renderer renderer;
            static IEnumerable<Department> list_of_departments_in_department;
            static ViewDepartmentInDepartmentRequest request;
            static Departments deparments;
            static Department department;
        }
    }
}
