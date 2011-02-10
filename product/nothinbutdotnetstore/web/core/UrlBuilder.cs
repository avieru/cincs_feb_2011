using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);

    public class UrlBuilder<CommandToRun,Model> where CommandToRun : ApplicationCommand
    {
        readonly object model;
        readonly NameValueCollection payload;

        public UrlBuilder(Model model, NameValueCollection payload)
        {
            this.model = model;
            this.payload = payload;
        }

        public void with<PropertyType>(PropertyAccessor<Model,PropertyType> accessor)
        {
            
            payload.Add("id",accessor((Model)model).ToString());
        }
    }
}