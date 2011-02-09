using System;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        
    }

    public class ViewDepartmentInDepartmentRequest : Request
    {
        public Department get_department_info()
        {
            throw new NotImplementedException();
        }
    }
}