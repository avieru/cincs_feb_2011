 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.specs
{   
    public class IsFirstItemSpecs
    {
        public abstract class concern : Observes<Criteria<int>,
                                            IsFirstItem<int>>
        {
        
        }

        [Subject(typeof(IsFirstItem<>))]
        public class when_asked_if_satisfied : concern
        {

            It should_only_be_satisfied_by_the_first_item = () =>
            {
                sut.is_satisfied_by(1).ShouldBeTrue();
                sut.is_satisfied_by(1).ShouldBeFalse();
            };
                
        }
    }
}
