using System;
using System.Reflection;

namespace nothinbutdotnetstore.core.containers
{
    public interface ConstructorSelectionStrategy
    {
        ConstructorInfo get_applicable_constructor_on(Type type);
    }
}