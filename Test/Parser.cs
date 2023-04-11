using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Parser
    {
        private string input;
        private int position;

        public Parser(string input)
        {
            this.input = input;
            position = 0;
        }

        public Node Parse()
        {
            Node root = new Node();
            ParseChildren(root);
            return root;
        }

        private void ParseChildren(Node parent)
        {
            while (position < input.Length)
            {
                SkipWhitespaceAndComments();

                if (position >= input.Length)
                {
                    break;
                }

                char ch = input[position];

                if (ch == '{')
                {
                    position++;
                    Node child = new Node(ReadName());
                    parent.Children.Add(child);
                    ParseChildren(child);
                }
                else if (ch == '}')
                {
                    position++;
                    return;
                }
                else if (ch == '=')
                {
                    position++;
                    string name = parent.Name ?? "";
                    string value = ReadValue();

                    if (parent.Value == null)
                    {
                        parent.Value = value;
                    }
                    else
                    {
                        parent.Values.Add(value);
                        parent.Value = string.Join(",", parent.Values);
                    }
                }
                else
                {
                    string name = ReadName();
                    if (parent.Name == null)
                    {
                        parent.Name = name;
                    }
                    else
                    {
                        Node child = new Node(name);
                        parent.Children.Add(child);
                    }
                }
            }
        }

        private void SkipWhitespaceAndComments()
        {
            while (position < input.Length)
            {
                char ch = input[position];
                if (char.IsWhiteSpace(ch))
                {
                    position++;
                }
                else if (ch == '#')
                {
                    position++;
                    while (position < input.Length && input[position] != '\n')
                    {
                        position++;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private string ReadName()
        {
            StringBuilder sb = new StringBuilder();
            while (position < input.Length && !char.IsWhiteSpace(input[position]) && input[position] != '{' && input[position] != '}')
            {
                sb.Append(input[position]);
                position++;
            }
            return sb.ToString();
        }

        private string ReadValue()
        {
            StringBuilder sb = new StringBuilder();
            while (position < input.Length && !char.IsWhiteSpace(input[position]) && input[position] != '}')
            {
                if (input[position] == '\"')
                {
                    position++;
                    while (position < input.Length && input[position] != '\"')
                    {
                        sb.Append(input[position]);
                        position++;
                    }
                    position++;
                }
                else
                {
                    sb.Append(input[position]);
                    position++;
                }
            }
            return sb.ToString();
        }
    }

}
