using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class RendererSpecs
    {
        public abstract class concern : Observes<Renderer, WebFormRenderer>
        {
        }

        [Subject(typeof(WebFormRenderer))]
        public class when_rendering : concern
        {
            Establish c = () =>
            {
                the_current_context = ObjectFactory.create_http_context();
                view_handler = an<IHttpHandler>();
                model_object = new OurModel();
                view_factory = the_dependency<ViewFactory>();

                view_factory.Stub(x => x.create_view_to_display(model_object))
                    .Return(view_handler);

                provide_a_basic_sut_constructor_argument<ActiveContextResolver>(() => the_current_context);
            };

            Because b = () =>
                sut.render(model_object);

            It should_tell_the_handler_that_can_render_the_model_to_execute_in_the_current_context = () =>
                view_handler.received(x => x.ProcessRequest(the_current_context));

            static OurModel model_object;
            static IHttpHandler view_handler;
            static HttpContext the_current_context;
            static ViewFactory view_factory;
        }

        class OurModel
        {
        }
    }
}