using System;

namespace nothinbutdotnetstore.core.containers
{
    public class BasicDependencyFactory : DependencyFactory
    {
        Func<object> dependency_item;

        public BasicDependencyFactory(Func<object> dependency_item)
        {
            this.dependency_item = dependency_item;
        }

        public object create()
        {
            return dependency_item();
        }
    }
}