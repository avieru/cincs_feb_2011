using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.core.containers
{
    public class GreedyConstructorSelectionStrategy : ConstructorSelectionStrategy
    {
        public ConstructorInfo get_applicable_constructor_on(Type type)
        {
            return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count())
                .First();
        }
    }
}