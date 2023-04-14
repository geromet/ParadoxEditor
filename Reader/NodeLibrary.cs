using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reader
{
    public static class NodeLibrary
    {
        public static async Task<Node> ParseInput(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var parser = new Parser(reader);
            var rootNode = await parser.ParseAsync();
            var inputFileRecord = new InputFile { FilePath = filePath, RootNode = rootNode };

            return rootNode;
        }

        public static string Print(Node node)
        {
            var sb = new StringBuilder();
            PrintNode(sb, node, 0);
            return sb.ToString();
        }
        private static void PrintNode(StringBuilder sb, Node node, int indent)
        {
            sb.Append($"{new string('\t', indent + 1)}{node.Name}");
            if (node.Value is not null)
            {
                sb.AppendLine($" = {node.Value}");
            }
            else if (node.Values.Count > 0)
            {
                sb.AppendLine($" =");
                foreach (string value in node.Values)
                {
                    sb.AppendLine($"{new string('\t', indent + 2)}{value}");
                }
            }

            if (node.Children.Count > 0)
            {
                sb.AppendLine($" =");
                foreach (Node child in node.Children)
                {
                    PrintNode(sb, child, indent + 2);
                }
            }
        }
        private static void PrintNodeDebug(StringBuilder sb, Node node, int indent)
        {
            sb.AppendLine($"{new string('\t', indent)}Node");
            sb.AppendLine($"{new string('\t', indent)}{{");
            sb.AppendLine($"{new string('\t', indent + 1)}Name = {node.Name}");
            if (node.Value is not null)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Value = {node.Value}");
            }
            else if (node.Values.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Values =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (string value in node.Values)
                {
                    sb.AppendLine($"{new string('\t', indent + 2)}{value}");
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }

            if (node.Children.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Children =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (Node child in node.Children)
                {
                    PrintNode(sb, child, indent + 2);
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }

            sb.AppendLine($"{new string('\t', indent)}}}");
        }
    }

}
