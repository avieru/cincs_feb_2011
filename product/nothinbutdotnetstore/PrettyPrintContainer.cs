using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public interface PrettyPrintContainer
    {
        string print_contents();
        IEnumerable<PrettyPrintContainer> children();
    }
}