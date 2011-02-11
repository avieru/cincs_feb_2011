using System;

namespace nothinbutdotnetstore.core.containers
{
    public class Container
    {
        public static ContainerFactory container_factory = () =>
        {
            throw new NotImplementedException("This needs to be configured by the startup process");
        };

        public static DependencyContainer resolve
        {
            get { throw new NotImplementedException(); }
        }
    }
}