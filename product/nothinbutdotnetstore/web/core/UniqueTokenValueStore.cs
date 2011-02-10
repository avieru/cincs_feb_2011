namespace nothinbutdotnetstore.web.core
{
    public interface UniqueTokenValueStore
    {
        void store_token_value(string token_key,object value);
    }
}