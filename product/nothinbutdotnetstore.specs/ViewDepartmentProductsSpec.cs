 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;
namespace nothinbutdotnetstore.specs
{   
    public class ViewDepartmentProductsSpec
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentProducts>
        {
        
        }

        [Subject(typeof(ViewDepartmentProducts))]
        public class when_observation_name : concern
        {
            Establish c = () =>
            {
                request =  an<Request>();
                renderer = the_dependency<Renderer>();
                departments = the_dependency<Departments>();
                list_of_products = new List<Product> {new Product()};
                department = new Department();

                request.Stub(x => x.map<Department>()).Return(department);
                departments.Stub(x => x.get_products_for(department)).Return(list_of_products);
            };

            Because b = () =>
                sut.run(request);


            It should_send_products_to_render = () =>
                renderer.received(x => x.render(list_of_products));


            static Renderer renderer;
            static IEnumerable<Product> list_of_products;
            static Departments departments;
            static Department department;
            static Request request;
        }
    }
}
