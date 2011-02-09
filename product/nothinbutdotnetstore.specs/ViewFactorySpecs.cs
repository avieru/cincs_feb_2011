using System;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class ViewFactorySpecs
    {
        public abstract class concern : Observes<ViewFactory,
                                            WebFormViewFactory>
        {
        }

        [Subject(typeof(WebFormViewFactory))]
        public class when_creating_a_view_for_a_report_model : concern
        {
            Establish c = () =>
            {
                the_path = "blah.aspx";
                the_model = new OurModel();
                form_path_registry = the_dependency<FormPathRegistry>();
                expected_args = new FactoryArgs(the_path,typeof(ViewFor<OurModel>));
                our_view = an<ViewFor<OurModel>>();

                form_path_registry.Stub(x => x.get_path_to_view_that_can_render<OurModel>())
                    .Return(the_path);

                provide_a_basic_sut_constructor_argument<PageFactory>((path,type) =>
                {
                    args_received = new FactoryArgs(path,type);
                    return our_view;
                });
            };

            Because b = () =>
                result = sut.create_view_to_display(the_model);


            It should_populate_the_view_with_its_report_model = () =>
            {
                result.downcast_to<ViewFor<OurModel>>().model.ShouldEqual(the_model);
            };

            It should_have_created_the_view_with_the_correct_information = () =>
            {
                args_received.base_type.ShouldEqual(expected_args.base_type);
                args_received.path.ShouldEqual(expected_args.path);
            };
  
            It should_return_the_view_that_can_display_the_model = () =>
                result.ShouldEqual(our_view);
  


            static IHttpHandler result;
            static OurModel the_model;
            static ViewFor<OurModel> our_view;
            static FormPathRegistry form_path_registry;
            static string the_path;
            static FactoryArgs args_received;
            static FactoryArgs expected_args;
        }

        public class OurModel
        {
        }
    }

    public class FactoryArgs
    {
        public string path { get; set; }
        public Type base_type { get; set; }

        public FactoryArgs(string path, Type base_type)
        {
            this.path = path;
            this.base_type = base_type;
        }
    }
}