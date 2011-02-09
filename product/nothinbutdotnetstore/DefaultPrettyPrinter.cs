using System.IO;

namespace nothinbutdotnetstore
{
    public class DefaultPrettyPrinter : PrettyPrinter
    {
        private TextWriter out_writer;
        DefaultPrettyPrintContainer root;
        public DefaultPrettyPrinter(TextWriter out_writer, string start)
        {
            this.out_writer = out_writer;
            this.root = new DefaultPrettyPrintContainer(start, 0);
        }

        public void print()
        {
            this.out_writer.Write(root.print_contents());
        }
    }
}