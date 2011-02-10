 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UniqueTokenValueStoreSpecs
    {
        public abstract class concern : Observes<UniqueTokenValueStore,
                                            DefaultUniqueTokenValueStore>
        {
        
        }

        [Subject(typeof(DefaultUniqueTokenValueStore))]
        public class when_adding_an_item_to_the_store : concern
        {
            Because b = () =>
                sut.store_token_value("some_key", 2);

            It should_check_to_see_if_the_key_is_already_in_the_store = () =>
                sut.received(x => x.is_already_in_the_store("some_key"));

        }
    }
}
