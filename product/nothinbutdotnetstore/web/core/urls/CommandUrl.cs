using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public class CommandUrl
    {
        public static UrlBuilderFactory<CommandToTarget> to_run<CommandToTarget>() where CommandToTarget : ApplicationCommand
        {
            return new UrlBuilderFactory<CommandToTarget>(
                new DefaultExpressionToPropertyNameMapper(),
                () => new DefaultUniqueTokenValueStore()
                );
        }
    }
}