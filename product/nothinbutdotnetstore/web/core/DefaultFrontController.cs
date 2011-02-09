using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry registery;

        public DefaultFrontController(CommandRegistry registery)
        {
            this.registery = registery;
        }

        public void process(Request request)
        {
            this.registery.get_the_command_that_can_process(request).run(request);
        }
    }
}