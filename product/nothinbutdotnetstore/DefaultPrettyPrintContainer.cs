using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore
{
    public class DefaultPrettyPrintContainer : PrettyPrintContainer
    {
        string start;
        int indent_level;
        StringBuilder string_builder;

        public DefaultPrettyPrintContainer(string start, int indent_level)
        {
            this.start = start;
            this.string_builder = new StringBuilder();
            this.indent_level = indent_level;
        }

        public string print_contents()
        {
            string_builder.AppendLine(indenter() + "+" + this.start);
            foreach (PrettyPrintContainer child in children())
            {
                string_builder.Append(child.print_contents())
            }
            return string_builder.ToString();
        }

        public IEnumerable<PrettyPrintContainer> children()
        {
            return null;
        }

        private string indenter()
        {
            StringBuilder indent = new StringBuilder();
            for (var i=0; i < indent_level; i++)
            {
                indent.Append("\t");
            }
            return indent.ToString();
        }
    }
}