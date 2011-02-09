using System.Collections;
using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class RendererSpecs
    {
        public abstract class concern : Observes<Renderer>
        {
        
        }

        [Subject(typeof(Renderer))]
        public class when_renderer_renders : concern
        {
            Because b = () =>
                sut.render(model_object);

            It transfers_to_aspx = () =>
                server_utility.received(x => x.Transfer(template_path));

            It adds_model_to_context = () =>
                server_context_items.received(x => x.Add(model_key, model_object))

            static IDictionary server_context_items;
            static HttpServerUtility server_utility;
            static string template_path;
            static object model_object;
            static object model_key;
        }
    }
}
