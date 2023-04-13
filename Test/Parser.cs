using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Parser
    {
        private readonly TextReader _reader;
        private string? _line;

        public Parser(TextReader reader)
        {
            _reader = reader;
        }

        public Node Parse()
        {
            Node root = new();
            while ((_line = _reader.ReadLine()) is not null)
            {
                _line = _line.Trim();
                if (_line.Length == 0 || _line.StartsWith('#'))
                {
                    continue;
                }

                Node node = ParseNode();
                root.Children.Add(node);
            }

            return root;
        }

        private Node ParseNode()
        {
            Node node = new() { Name = ParseName() };
            if (_line == "=")
            {
                node.Value = ParseValue();
                return node;
            }

            if (_line == "{")
            {
                while ((_line = _reader.ReadLine()) is not null)
                {
                    _line = _line.Trim();
                    if (_line.Length == 0 || _line.StartsWith('#'))
                    {
                        continue;
                    }

                    if (_line == "}")
                    {
                        break;
                    }

                    Node childNode = ParseNode();
                    if (childNode.Name == "Values")
                    {
                        node.Values.AddRange(childNode.Values);
                    }
                    else
                    {
                        node.Children.Add(childNode);
                    }
                }
            }

            return node;
        }

        private string ParseName()
        {
            string[] parts = _line.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            _line = parts.Length > 1 ? parts[1] : "=";
            return parts[0];
        }

        private string ParseValue()
        {
            if (_line.StartsWith("{"))
            {
                var values = new List<string>();
                while ((_line = _reader.ReadLine()) is not null)
                {
                    _line = _line.Trim();
                    if (_line.Length == 0 || _line.StartsWith('#'))
                    {
                        continue;
                    }

                    if (_line == "}")
                    {
                        break;
                    }

                    values.Add(_line);
                }
                Node valuesNode = new() { Name = "Values", Values = values };
                return valuesNode.ToString();
            }

            string value = _line;
            _line = null;
            return value;
        }
    }

}
