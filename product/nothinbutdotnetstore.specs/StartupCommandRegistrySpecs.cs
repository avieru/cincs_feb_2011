 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs
{   
    public class StartupCommandRegistrySpecs
    {
        public abstract class concern : Observes<StartupCommandRegistry>
        {
        
        }

        [Subject(typeof(StartupCommandRegistry))]
        public class when_adding_additional_startup_commands_to_start_pipeline : concern
        {
            Establish c = () =>
            {
              list_of_commands = new List<Type>{ };
              provide_a_basic_sut_constructor_argument(list_of_commands);
            };

            Because b = () =>
                result = sut.then_by<SomeStartUpCommmand>();

            It should_return_itself = () =>
                result.ShouldBeAn<StartupCommandRegistry>();

            It should_contain_in_the_list_of_commands = () =>
                list_of_commands.ShouldContain(typeof(SomeStartUpCommmand));

            static StartupCommandRegistry result;
            static IList<Type> list_of_commands;
        }

        [Subject(typeof(StartupCommandRegistry))]
        public class when_adding_final_command_and_finalizing_the_startup_pipeline : concern
        {
            Establish c = () =>
            {
                list_of_commands = new List<Type> { typeof(FirstStartupCommand) };
                startup_command_runner = the_dependency<StartupCommandRunner>();
                provide_a_basic_sut_constructor_argument(list_of_commands);
            };

            Because b = () =>
                sut.finish_by<SomeStartUpCommmand>();

            It should_contain_in_the_list_of_commands = () =>
                list_of_commands.ShouldContain(typeof(SomeStartUpCommmand));

            It should_call_command_runner = () =>
                startup_command_runner.received(x => x.run_commands(list_of_commands));


            static StartupCommandRegistry result;
            static IList<Type> list_of_commands;
            static StartupCommandRunner startup_command_runner;
        }
        
        
        public class FirstStartupCommand: StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }

        class SomeStartUpCommmand : StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }
    }


}
