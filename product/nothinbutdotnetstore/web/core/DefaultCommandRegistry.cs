using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        readonly IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            return all_commands.ToList().Find(x => x.can_handle(request));
        }
    }
}