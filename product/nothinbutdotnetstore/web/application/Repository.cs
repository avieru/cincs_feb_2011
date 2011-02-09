using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
   public interface Repository
    {
        IList<Department> get_departments();
    }

    public class Department
    {
    }
}