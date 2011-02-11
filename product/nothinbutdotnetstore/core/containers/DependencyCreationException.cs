using System;

namespace nothinbutdotnetstore.core.containers
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Exception inner, Type the_type) : base("", inner)
        {
            dependency_that_could_not_be_created = the_type;
        }

        public Type dependency_that_could_not_be_created { get; private set; }
    }
}