 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewProductsInDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProductsInDepartmentCommand>
        {
        
        }

        [Subject(typeof(ViewProductsInDepartmentCommand))]
        public class when_run : concern
        {

            Establish c = () =>
            {
                request = an<Request>();
                renderer = the_dependency<Renderer>();
                products = the_dependency<Products>();
                input_model = new ProductsByDepartmentInput();
                request.Stub(x => x.map<ProductsByDepartmentInput>()).Return(input_model);
                list_of_products_by_department = new List<Product>();
                products.Stub(x => x.get_products_by(input_model)).Return(list_of_products_by_department);
            };

            Because b = () =>
                sut.run(request);


            It should_render_view_with_products = () =>   
                renderer.received(x => x.render(list_of_products_by_department));

            static Renderer renderer;
            static IEnumerable<Product> list_of_products_by_department;
            static Request request;
            static ProductsByDepartmentInput input_model;
            static Products products;
        }
    }

    public interface Products
    {
        IEnumerable<Product> get_products_by(ProductsByDepartmentInput input_model);
    }

    public class ProductsByDepartmentInput
    {
    }

    public class Product
    {
    }

    public class ViewProductsInDepartmentCommand : ApplicationCommand
    {
        readonly Products products;
        readonly Renderer renderer;

        public ViewProductsInDepartmentCommand(Products products, Renderer renderer)
        {
            this.products = products;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(products.get_products_by(request.map<ProductsByDepartmentInput>()));
        }
    }
}
