using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public void by<CommandToStartTheChain>() where CommandToStartTheChain : StartupCommand
        {
            throw new NotImplementedException();
        }
    }
}