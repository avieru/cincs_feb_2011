using System;

namespace nothinbutdotnetstore.web.core
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);

    public class UrlBuilder<CommandToRun,Model> where CommandToRun : ApplicationCommand
    {
        public void with<PropertyType>(PropertyAccessor<Model,PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }
}