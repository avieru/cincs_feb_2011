using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria request_criteria;
        readonly ApplicationCommand application_command;

        public DefaultRequestCommand(RequestCriteria request_criteria,ApplicationCommand application_command)
        {
            this.request_criteria = request_criteria;
            this.application_command = application_command;
        }

        public void run(Request request)
        {
            application_command.run(request);
        }

        public bool can_handle(Request request)
        {
            return request_criteria(request);
        }
    }
}