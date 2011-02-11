 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using nothinbutdotnetstore.web.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using System.Linq;

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
            Establish c = () =>
            {
                all_tokens = new Dictionary<string, object>();
            };


            Because b = () =>
            {
                sut.downcast_to<DefaultUniqueTokenValueStore>().tokens = all_tokens;

                sut.store_token_value("some_key", 2);
            };

            It should_add_the_pair_to_the_list_of_tokens = () =>
                all_tokens["some_key"].ShouldEqual(2);

            static IDictionary<string,object> all_tokens;

        }

        public class when_attempting_to_add_a_token_with_the_same_key_twice : concern
        {
            Establish c = () =>
            {
                duplicate = "dup";
                all_tokens = new Dictionary<string, object>();
                all_tokens.Add(duplicate,23);
            };


            Because b = () =>
            {
                sut.downcast_to<DefaultUniqueTokenValueStore>().tokens = all_tokens;
                sut.store_token_value(duplicate, 2);
            };

            It should_preserve_the_original_value = () =>
                all_tokens[duplicate].ShouldEqual(23);

            static IDictionary<string,object> all_tokens;
            static string duplicate;
        }

        public class when_multiple_unique_tokens_are_added : concern
        {
            Establish c = () =>
            {
                duplicate = "dup";
                all_tokens = new Dictionary<string, object>();
            };


            Because b = () =>
            {
                sut.downcast_to<DefaultUniqueTokenValueStore>().tokens = all_tokens;
                sut.store_token_value(duplicate, 2);
                sut.store_token_value("blah", 2);
                sut.store_token_value("sdfsdf", 2);
            };

            It should_preserve_the_original_value = () =>
                all_tokens.Count.ShouldEqual(3);

            static IDictionary<string,object> all_tokens;
            static string duplicate;
        }

        public class when_iterating : concern
        {
            Establish c = () =>
            {
                all_tokens = new Dictionary<string, object>();
                all_tokens.Add("blah", 2);
                all_tokens.Add("sdfsdf", 2);
            };


            Because b = () =>
            {
                sut.downcast_to<DefaultUniqueTokenValueStore>().tokens = all_tokens;

                result = sut;
            };

            It should_return_the_iterator_for_keyvalue_pair_instances_of_items_in_the_store = () =>
                result.Count().ShouldEqual(2);

            static IDictionary<string,object> all_tokens;
            static IEnumerable<KeyValuePair<string,object>> result;
        }
        
    }
}
