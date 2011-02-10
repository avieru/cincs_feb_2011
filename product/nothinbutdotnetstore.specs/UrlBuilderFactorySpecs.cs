 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlBuilderFactorySpecs
    {
        public abstract class concern : Observes<UrlBuilderFactory>
        {
        
        }

        public class when_building_up_url_builder : concern
        {
            Establish c = () =>
            {
                the_model = new NotTheirModel();
            };

            Because b = () =>
                sut.For<CommandToRun,NotTheirModel>(the_model);


            It first_observation = () =>
                result.ShouldBeAn<UrlBuilder<CommandToRun, NotTheirModel>>();

            static UrlBuilder<CommandToRun,NotTheirModel> result;
            static NotTheirModel the_model;
        }
    }

    class CommandToRun : ApplicationCommand
    {
        public void run(Request request)
        {
            throw new NotImplementedException();
        }
    }

    class NotTheirModel
    {
    }

    public interface UrlBuilderFactory
    {
        UrlBuilder<Command,ReportModel> For<Command,ReportModel>(ReportModel the_model) where Command : ApplicationCommand;
    }
}
