using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalog : Catalog
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return create_a_set_of(100, create_a_department);
        }

        public IEnumerable<Department> get_departments_in(Department department)
        {
            return create_a_set_of(100, create_a_department);
        }

        public IEnumerable<Product> get_products_in(Department department)
        {
            return create_a_set_of(100, x => new Product
            {
                name = x.ToString("Product 0"),
                description =
                                            x.ToString("Description 0"),
                price = x
            });
        }

        static Department create_a_department(int number)
        {
            return new Department
            {
                name = number.ToString("Department 0"),
                number_of_products = (number%2 == 0 ? 3 : 0)
            };
        }

        static IEnumerable<Item> create_a_set_of<Item>(int number, Func<int, Item> factory)
        {
            return Enumerable.Range(1, number).Select(factory);
        }
    }
}