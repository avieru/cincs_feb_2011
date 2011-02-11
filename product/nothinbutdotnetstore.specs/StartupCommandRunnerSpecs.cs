 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs
{   
    public class StartupCommandRunnerSpecs
    {
        public abstract class concern : Observes<StartupCommandRunner,
                                            DefaultStartupCommandRunner>
        {
        
        }

        [Subject(typeof(DefaultStartupCommandRunner))]
        public class when_run_commands_is_called : concern
        {
            Establish c = () =>
            {
                list_of_commands = new List<Type>{typeof(FirstComand),typeof(SecondCommand)};
                command_visitor = an<StartupCommandVisitor>();
                provide_a_basic_sut_constructor_argument(command_visitor);
            };

            Because b = () =>
                sut.run_commands(list_of_commands);


            It should_dispatch_a_call_to_process_on_the_visitor = () =>
                command_visitor.received(x => x.process(list_of_commands[0]));


            static IList<Type> list_of_commands;
            static StartupCommandVisitor command_visitor;
        }
    }

    public class FirstComand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }

    public class SecondCommand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }
}
