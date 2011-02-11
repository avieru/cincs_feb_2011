 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core.containers;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class BasicDependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_resolving_an_dependency : concern
        {
            Establish c = () =>
            {
                resolver = the_dependency<IResolver>();
                type_of_result = result.GetType();
                result = an<OurOwnType>();
                resolver.Stub(x => x.provide_mapped_instance_for(type_of_result)).Return(result);
            };

            Because b = () =>
                result = sut.an<IOurOwn>();

            It should_ask_resolver_to_provide_mapped_type = () =>
                resolver.received(x => x.provide_mapped_instance_for(type_of_result));

            It should_return_an_instance_of_the_contract = () =>
                result.ShouldBeAn<IOurOwn>();

            static IOurOwn result;
            static IResolver resolver;
            static Type type_of_result;
        }
    }

   public interface IResolver
    {
        void provide_mapped_instance_for<SomeType>(SomeType type_of_result);
    }

    public interface IOurOwn
    {
        
    }

    public class OurOwnType : IOurOwn
    {
        
    }
    public class BasicDependencyContainer: DependencyContainer
    {
        readonly IResolver i_resolver;

        public BasicDependencyContainer(IResolver i_resolver)
        {
            this.i_resolver = i_resolver;
        }

        public Dependency an<Dependency>()
        {
            throw new NotImplementedException("");
        }
    }
}
