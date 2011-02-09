﻿using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.tasks
{
    public interface Departments
    {
        IEnumerable<Department> get_the_main_departments();
        IEnumerable<Department> get_departments_in(Department department);
        IEnumerable<Product> get_products_for(Department department);
    }
}