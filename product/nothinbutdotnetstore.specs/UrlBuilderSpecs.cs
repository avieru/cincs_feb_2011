 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlBuilderSpecs
    {
        public abstract class concern : Observes<UrlBuilder<TCommand>>
        {
        
        }

        [Subject(typeof(UrlBuilder<TCommand>))]
        public class when_calling_the_with : concern
        {
            Establish c = () =>
            {
                property_delegate = PropertyAccessor<>
            };

            Because b = () =>
            {
                sut.with<OurModel>(x => x.id);
            };


            It should_return_a_url = () =>
            {
                
            };
        }
    }

    public delegate PropertyType PropertyAccessor<ReportModel, PropertyType>(ReportModel item);

    public class OurModel
    {
        public string id { get; set; }

    }

    public class UrlBuilder<TCommand> where TCommand: ApplicationCommand
    {
        public void with<ReportModel>()
        {
            throw new NotImplementedException();
        }
    }
}
