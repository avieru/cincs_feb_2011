 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UniqueValueStoreSpecs
    {
        public abstract class concern : Observes<UniqueTokenValueStore,
                                            SimpleUniqueTokenValueStore>
        {
        
        }

        [Subject(typeof(SimpleUniqueTokenValueStore))]
        public class when_adding_duplicate_values_to_the_store : concern
        {
            Establish c = () =>
            {
                
            };

            Because b = () =>
            {
                sut.store_token_value("token", "value");
                sut.store_token_value("token", "value");
            };


            It should_only_add_one_pair = () =>
                sut.ToList().Count.ShouldEqual(1);

            static IEnumerable<KeyValuePair<string,object>> result;
                
        }
    }

    public class SimpleUniqueTokenValueStore : UniqueTokenValueStore
    {
        IList<KeyValuePair<string, object>> items = new List<KeyValuePair<string, object>>();
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void store_token_value(string token_key, object value)
        {
            if (items.Contains(new KeyValuePair<string, object>(token_key, value))) return;
            
            items.Add(new KeyValuePair<string, object>(token_key,value));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
