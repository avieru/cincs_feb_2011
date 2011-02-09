using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface Departments
    {
        IEnumerable<Department> get_the_main_departments();
    }
}