 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs
{   
    public class StartSpecs
    {
        public abstract class concern : Observes
        {
        
        }

        [Subject(typeof(Start))]
        public class when_adding_first_startup_command_to_start_pipeline : concern
        {
            Because b = () =>
               result = Start.by<SomeStartUpCommmand>();

            It should_return = () =>
                result.ShouldBeAn<StartupCommandRegistry>();

            static StartupCommandRegistry result;        
                
        }

        class SomeStartUpCommmand: StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }
    }
}
