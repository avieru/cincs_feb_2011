using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.core
{
    public class CommonFactories
    {
        public static readonly TokenStoreFactory token_store_factory = () =>
            new DefaultUniqueTokenValueStore();

        public static readonly UrlEncoderFactory encoder_factory = new StubEncoderFactory().build;

    }
}