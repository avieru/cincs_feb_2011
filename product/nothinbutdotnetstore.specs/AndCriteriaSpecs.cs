 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.specs
{   
    public class AndCriteriaSpecs
    {
        public abstract class concern : Observes<Criteria<int>,
                                            AndCriteria<int>>
        {
        
        }

        [Subject(typeof(AndCriteria<>))]
        public class when_determining_if_it_matches_an_item : concern
        {
            Establish c = () =>
            {
                first = new AlwaysMatches();
                second = new AlwaysMatches();
                create_sut_using(() => new AndCriteria<int>(first,second));
            };

            Because b = () =>
                result = sut.is_satisfied_by(2);


            It should_match_if_both_of_its_criteria_match = () =>
                result.ShouldBeTrue();


            static bool result;
            static Criteria<int> second;
            static Criteria<int> first;
        }
    }

    class AlwaysMatches : Criteria<int>
    {
        public bool is_satisfied_by(int item)
        {
            return true;
        }
    }
}
