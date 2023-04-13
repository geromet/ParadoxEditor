using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Node
    {
        public string? Name { get; init; }
        public List<Node> Children { get; } = new();
        public string? Value { get; init; }
        public List<string> Values { get; } = new();

        public override string ToString() => ToString(0);

        public string ToString(int indent)
        {
            var sb = new StringBuilder();
            BuildString(sb, indent);
            return sb.ToString();
        }

        private void BuildString(StringBuilder sb, int indent)
        {
            sb.AppendLine($"{new string('\t', indent)}Node");
            sb.AppendLine($"{new string('\t', indent)}{{");
            sb.AppendLine($"{new string('\t', indent + 1)}Name = {Name}");
            if (Value is not null)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Value = {Value}");
            }
            else if (Values.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Values =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (var value in Values)
                {
                    sb.AppendLine($"{new string('\t', indent + 2)}{value}");
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }
            if (Children.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Children =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (var child in Children)
                {
                    child.BuildString(sb, indent + 2);
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }
            sb.AppendLine($"{new string('\t', indent)}}}");
        }

    }
