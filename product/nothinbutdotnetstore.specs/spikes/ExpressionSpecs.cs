using System;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.spikes
{
    public class Expressionspecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Expression))]
        public class when_messing_around_with_expressions : concern
        {
            It should_be_able_to_get_the_name_of_a_property_pointed_at_by_an_expression = () =>
            {
                ExpressionUtility.name_of_property_on<TheItem,string>(x => x.name).ShouldEqual("name");
            };

            It should_be_able_to_create_a_block_of_code_dynamically = () =>
            {
                Func<int, bool> is_even = x => x%2 == 0;
                var numbers = Enumerable.Range(1,100);

                var results = numbers.Where(x => x%2 == 0);

                var results2 = from number in numbers
                               where number%2 == 0
                               select number;

                is_even(2).ShouldBeTrue();

                var number_2 = Expression.Constant(2);
                var parameter = Expression.Parameter(typeof(int), "x");
                var modulus = Expression.Modulo(parameter,number_2);
                var is_equal = Expression.Equal(modulus, Expression.Constant(0));
                var dynamic_method = Expression.Lambda<Func<int, bool>>(is_equal, parameter);

                dynamic_method.Compile()(2).ShouldBeTrue();
            };
  
        }
    }

    class TheItem
    {
        public string name { get; set; }
    }

    public class ExpressionUtility
    {
        public static string name_of_property_on<ElementToInterrogate,PropertyType>(Expression<Func<ElementToInterrogate, PropertyType>> accessor)
        {
            return accessor.Body.downcast_to<MemberExpression>().Member.Name;
        }
    }
}
