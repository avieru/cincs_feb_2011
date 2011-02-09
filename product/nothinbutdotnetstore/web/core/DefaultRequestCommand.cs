using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria request_criteria;

        public DefaultRequestCommand(RequestCriteria request_criteria)
        {
            this.request_criteria = request_criteria;
        }

        public void run(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(Request request)
        {
            return request_criteria.Invoke(request);
        }
    }
}