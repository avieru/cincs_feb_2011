using nothinbutdotnetstore.core;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.core
{
    public class WebFactories
    {
        public static readonly TokenStoreFactory token_store_factory = () =>
            new DefaultUniqueTokenValueStore();

        public static readonly UrlEncoderFactory encoder_factory = new StubEncoderFactory().build;

        public static readonly SpecialCaseDependencyFactory special_case_dependency_factory =
            (type_that_has_no_factory) => new StubMissingDependencyFactory(type_that_has_no_factory);


    }
}