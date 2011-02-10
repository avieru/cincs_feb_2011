using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{
    public class CommandUrlSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(CommandUrl))]
        public class when_creating_a_url_builder_factory_for_a_specific_command : concern
        {
            Because b = () =>
                result = CommandUrl.to_run<ThisCommand>();

            It should_create_a_correct_url_builder_factory = () =>
                result.ShouldBeAn<UrlBuilderFactory<ThisCommand>>();

            static UrlBuilderFactory<ThisCommand> result;
        }

        public class ThisCommand : ApplicationCommand
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}