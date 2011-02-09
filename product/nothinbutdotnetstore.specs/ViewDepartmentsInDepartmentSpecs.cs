 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewDepartmentsInDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentsInDepartment>
        {
        
        }

        [Subject(typeof(ViewDepartmentsInDepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                renderer = the_dependency<Renderer>();
                deparments = the_dependency<Departments>();
                list_of_departments_in_department = new List<Department> {new Department()};
                parent_department = new Department();

                request.Stub(x => x.map<Department>()).Return(parent_department);

                deparments.Stub(x => x.get_departments_in(parent_department))
                    .Return(list_of_departments_in_department);

            };


            Because b = () =>
                sut.run(request);


            It should_send_departments_to_renderer = () =>
                renderer.received(x => x.render(list_of_departments_in_department));


            static Renderer renderer;
            static IEnumerable<Department> list_of_departments_in_department;
            static Departments deparments;
            static Department parent_department;
            static Request request;
        }
    }
}
