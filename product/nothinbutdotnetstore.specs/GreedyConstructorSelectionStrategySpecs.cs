using System.Configuration;
using System.Data;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.specs.spikes;

namespace nothinbutdotnetstore.specs
{
    public class GreedyConstructorSelectionStrategySpecs
    {
        public abstract class concern : Observes<ConstructorSelectionStrategy,
                                            GreedyConstructorSelectionStrategy>
        {
        }

        [Subject(typeof(GreedyConstructorSelectionStrategy))]
        public class when_getting_the_applicable_constructor_on_a_type : concern
        {
            Establish c = () =>
            {
                the_greediest_constructor = ExpressionUtility.constructor_pointed_at_by(() =>
                                                                                            new OurType(null, null, null,
                                                                                                        null)); 
            };
            Because b = () =>
                result = sut.get_applicable_constructor_on(typeof(OurType));


            It should_return_the_constructor_with_the_most_parameters = () =>
                result.ShouldEqual(the_greediest_constructor);

            static ConstructorInfo result;
            static ConstructorInfo the_greediest_constructor;
        }

        public class OurType
        {
            public OurType(IDbConnection first, IDbCommand second, IDataReader third, ConnectionStringSettings fourth)
            {
                this.first = first;
                this.second = second;
                this.third = third;
                this.fourth = fourth;
            }

            public OurType(IDbConnection first, IDbCommand second)
            {
                this.first = first;
                this.second = second;
            }

            public OurType(IDbCommand second, ConnectionStringSettings fourth)
            {
                this.second = second;
                this.fourth = fourth;
            }

            public IDbConnection first { get; set; }
            public IDbCommand second { get; set; }
            public IDataReader third { get; set; }
            public ConnectionStringSettings fourth { get; set; }
        }
    }
}