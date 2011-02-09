using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface DepartmentStore
    {
        IEnumerable<Department> get_departments();
    }
}