using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Startup))]
        public class when_the_application_has_completed_its_startup_process : concern
        {
            Because b = () =>
                Startup.run();

            It everything_should_be_ready_to_roll = () =>
            {
                Container.resolve.ShouldBeAn<BasicDependencyContainer>();
                Container.resolve.an<FrontController>().ShouldBeAn<DefaultFrontController>();
                Container.resolve.an<RequestFactory>().ShouldNotBeNull();
            };
        }
    }
}