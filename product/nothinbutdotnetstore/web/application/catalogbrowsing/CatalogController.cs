using System.Collections.Generic;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class CatalogController
    {
        Catalog catalog;

        public CatalogController(Catalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<Department> get_the_main_departments()
        {
            return catalog.get_the_main_departments();
        }

        public IEnumerable<Department> get_departments_in(Department department)
        {
            return catalog.get_departments_in(department);
        }

        public IEnumerable<Product> get_products_in(Department department)
        {
            return catalog.get_products_in(department);
        }
    }
}