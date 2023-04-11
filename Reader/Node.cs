using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Node
    {
        public string Name;
        public List<Node>? Children;
        public string? Value;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            PrintNode(this, 0, sb);
            return sb.ToString();
        }

        private void PrintNode(Node node, int depth, StringBuilder sb)
        {
            if (node.Children != null)
            {
                sb.Append(new string(' ', depth * 4));
                sb.AppendLine(node.Name);

                foreach (Node child in node.Children)
                {
                    PrintNode(child, depth + 1, sb);
                }
            }
            else
            {
                sb.Append(new string(' ', depth * 4));
                sb.Append(node.Name);

                if (node.Value != null)
                {
                    sb.Append(" = ");
                    sb.Append(node.Value);
                }

                sb.AppendLine();
            }
        }
    }
}