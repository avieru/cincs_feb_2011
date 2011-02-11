using System;

namespace nothinbutdotnetstore.core.containers
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Type dependency)
        {
            dependency_that_could_not_be_created = dependency;
        }

        public Type dependency_that_could_not_be_created { get; private set; }
    }
}