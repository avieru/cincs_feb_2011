namespace nothinbutdotnetstore.core.containers
{
    public class BasicDependencyContainer : DependencyContainer
    {
        DependencyFactories dependency_factories;

        public BasicDependencyContainer(DependencyFactories dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public Dependency an<Dependency>()
        {
            return
                cast_to<Dependency>(
                    dependency_factories.get_factory_that_can_create(typeof(Dependency)).create());
        }

        Dependency cast_to<Dependency>(object dependency)
        {
            return (Dependency) dependency;
        }
    }
}