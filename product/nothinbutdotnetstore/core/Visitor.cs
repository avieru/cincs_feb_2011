namespace nothinbutdotnetstore.core
{
    public interface Visitor<ItemToProcess>
    {
        void process(ItemToProcess item);
    }
}