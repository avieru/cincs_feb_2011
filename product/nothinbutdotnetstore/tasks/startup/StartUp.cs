using System;
using System.Collections.Generic;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
            DependencyContainer container =  new BasicDependencyContainer(
                new BasicDependencyFactories(all_factories, (type_that_has_no_factory) =>
                {
                    throw new NotImplementedException("You need to deal with the special case here");
                }));
            Container.container_factory = () => container;


            //do container configuration
        }
    }
}