using Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Reader
{
    public class Parser
    {
        private readonly TextReader _reader;
        private string _line;

        public Parser(TextReader reader)
        {
            _reader = reader;
        }

        public async Task<Node> ParseAsync()
        {
            Node rootNode = new Node();
            while ((_line = await _reader.ReadLineAsync()) != null)
            {
                _line = RemoveInlineComments(_line);
                if (_line.Trim().Length == 0) continue;
                ParseNode(rootNode);
            }
            return rootNode;
        }
        private string RemoveInlineComments(string line)
        {
            bool insideQuotes = false;
            int commentStart = -1;

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '\"')
                {
                    insideQuotes = !insideQuotes;
                }

                if (!insideQuotes && currentChar == '#')
                {
                    commentStart = i;
                    break;
                }
            }

            return commentStart >= 0 ? line.Substring(0, commentStart).Trim() : line;
        }
        private void ParseNode(Node parent)
        {
            _line = _line.Trim();
            if (string.IsNullOrEmpty(_line) || _line.StartsWith("#"))
                return;

            if (_line.EndsWith("{"))
            {
                Node node = new Node { Name = _line.TrimEnd('{').Trim().TrimEnd('=') };
                parent.Children.Add(node);
                while ((_line = _reader.ReadLine()) != null)
                {
                    _line = RemoveInlineComments(_line);
                    if (_line.Trim().StartsWith("}"))
                        break;
                    ParseNode(node);
                }
            }
            else if (_line.Contains("="))
            {
                var keyValue = _line.Split(new[] { '=' }, 2);
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim().TrimEnd(';');
                if (value.Contains("{"))
                {
                    Node node = new Node { Name = key };
                    parent.Children.Add(node);
                    ParseValues(value.Trim('{', '}', ' ').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), node);
                }
                else
                {
                    parent.Children.Add(new Node { Name = key, Value = value });
                }
            }
            else // For multiple strings without { } or = between them
            {
                string[] values = _line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ParseValues(values, parent);
            }
        }

        private void ParseValues(string[] values, Node node)
        {
            foreach (var value in values)
            {
                node.Values.Add(value.Trim());
            }
        }
    }
}
