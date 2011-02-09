using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry():this(new StubSetOfCommands())
        {
        }

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            //TODO - If we do this type of thing again, refactor
            return all_commands.FirstOrDefault(x => x.can_handle(request))
                ?? new MissingRequestCommand();
        }
    }
}