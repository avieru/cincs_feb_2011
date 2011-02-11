using System;

namespace nothinbutdotnetstore.core.containers
{
    public class DependencyCreationException : Exception
    {
        public Type dependency_that_could_not_be_created { get; private set; }
    }
}