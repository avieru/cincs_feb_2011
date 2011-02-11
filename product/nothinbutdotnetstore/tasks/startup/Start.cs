using System;
using System.Collections.Generic;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static StartupCommandRegistry by<CommandToStartTheChain>() where CommandToStartTheChain : StartupCommand
        {
            return new StartupCommandRegistry(new List<Type>(), new DefaultStartupCommandRunner(null));
        }
    }

    public class StartupCommandRegistry
    {
        readonly IList<Type> list_of_commands;
        readonly StartupCommandRunner startup_command_runner;

        public StartupCommandRegistry(IList<Type> list_of_commands, StartupCommandRunner startup_command_runner)
        {
            this.list_of_commands = list_of_commands;
            this.startup_command_runner = startup_command_runner;
        }

        public StartupCommandRegistry then_by<CommandToContinueTheChain>()
        {
            list_of_commands.Add(typeof(CommandToContinueTheChain));
            return this;
        }

        public void finish_by<CommandToFinalizeTheChain>()
        {
            list_of_commands.Add(typeof(CommandToFinalizeTheChain));
            startup_command_runner.run_commands(list_of_commands);
        }
    }

    public interface StartupCommandRunner
    {
        void run_commands(IList<Type> list_of_commands);
    }

    public class DefaultStartupCommandRunner : StartupCommandRunner
    {
        readonly StartupCommandVisitor startup_command_visitor;

        public DefaultStartupCommandRunner(StartupCommandVisitor startup_command_visitor)
        {
            this.startup_command_visitor = startup_command_visitor;
        }

        public void run_commands(IList<Type> list_of_commands)
        {
            list_of_commands.for_each(x => startup_command_visitor.process(x));
        }
    }

    public interface StartupCommandVisitor : Visitor<Type>
    {
    }
}