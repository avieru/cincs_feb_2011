using System;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.tasks.startup.stubs
{
    public class StubDependencyFactory<TypeToCreate> : DependencyFactory
    {
        DependencyFactory original;

        public StubDependencyFactory(DependencyFactory original)
        {
            this.original = original;
        }

        public object create()
        {
            try
            {
                return original.create();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(string.Format("Could not create an instance of the dependency {0}",
                                                                typeof(TypeToCreate).Name));
            }
        }
    }
}