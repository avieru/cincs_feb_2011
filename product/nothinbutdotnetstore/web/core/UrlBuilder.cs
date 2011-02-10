using System.Collections.Specialized;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);

    public class UrlBuilder<CommandToRun, Model> where CommandToRun : ApplicationCommand
    {
        readonly Model model;
        readonly NameValueCollection payload;

        public UrlBuilder(Model model, NameValueCollection payload)
        {
            this.model = model;
            this.payload = payload;
        }

        public void with<PropertyType>(Expression<PropertyAccessor<Model, PropertyType>> accessor)
        {
            payload.Add(((MemberExpression) accessor.Body).Member.Name, accessor.Compile()(model).ToString());
        }
    }
}