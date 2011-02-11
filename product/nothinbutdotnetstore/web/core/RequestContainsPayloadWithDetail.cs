using System;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class RequestContainsPayloadWithDetail<InputModel> : Criteria<Request>
    {
        Func<InputModel, bool> model_matcher;

        public RequestContainsPayloadWithDetail(Func<InputModel, bool> model_matcher)
        {
            this.model_matcher = model_matcher;
        }

        public bool is_satisfied_by(Request item)
        {
            return model_matcher(item.map<InputModel>());
        }
    }
}