using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Node
    {
        public string? Name;
        public List<Node> Children;
        public string? Value;
        public List<string> Values;

        public Node(string? name = null)
        {
            Name = name;
            Children = new List<Node>();
            Values = new List<string>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToString(sb, 0);
            return sb.ToString();
        }

        private void ToString(StringBuilder sb, int indent)
        {
            if (Name != null)
            {
                sb.Append(new string(' ', indent * 4));
                sb.Append(Name);
                if (Value != null && indent > 0)
                {
                    sb.Append(" = ");
                    sb.Append(Value);
                }
                sb.AppendLine();
            }

            foreach (var child in Children)
            {
                child.ToString(sb, indent + 1);
            }
        }
    }

}
