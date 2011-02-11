using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.specs
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Container))]
        public class when_providing_access_to_the_underlying_container : concern
        {
            Establish c = () =>
            {
                the_real_container = an<DependencyContainer>();

                ContainerFactory factory = () => the_real_container;
                change(() => Container.container_factory).to(factory);
            };

            Because b = () =>
                result = Container.resolve;

            It should_return_the_container_adapter_created_by_the_configured_container_factory = () =>
                result.ShouldEqual(the_real_container);

            static DependencyContainer result;
            static DependencyContainer the_real_container;
        }
    }
}