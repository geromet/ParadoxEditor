using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reader
{
    internal class Program
    {
        public static Node Main(string filePath = "00_country_ideas.txt")
        {
            string content = File.ReadAllText(filePath);
            Node rootNode = new Node
            {
                Name = Path.GetFileName(filePath),
                Children = new List<Node>()
            };

            string[] lines = content.Split('\n');
            StringBuilder filteredContent = new StringBuilder();

            foreach (string line in lines)
            {
                string[] parts = line.Split('#', StringSplitOptions.TrimEntries);
                if (parts.Length > 0)
                {
                    filteredContent.AppendLine(parts[0]);
                }
            }

            ParseContent(filteredContent.ToString(), 0, rootNode);
            return rootNode;
        }

        private static int ParseContent(string content, int index, Node parentNode)
        {
            while (index < content.Length)
            {
                if (char.IsLetter(content[index]))
                {
                    int equalsIndex = content.IndexOf('=', index);
                    string name = content.Substring(index, equalsIndex - index).Trim();

                    index = equalsIndex + 1;
                    while (char.IsWhiteSpace(content[index])) index++;

                    if (content[index] == '{')
                    {
                        Node currentNode = new Node
                        {
                            Name = name,
                            Children = new List<Node>()
                        };

                        parentNode.Children.Add(currentNode);
                        index = ParseContent(content, index + 1, currentNode);
                    }
                    else
                    {
                        int valueEnd = content.IndexOfAny(new[] { '\n', '}' }, index);
                        if (valueEnd == -1)
                        {
                            valueEnd = content.Length;
                        }

                        string value = content.Substring(index, valueEnd - index).Trim();

                        parentNode.Children.Add(new Node
                        {
                            Name = name,
                            Value = value
                        });

                        index = valueEnd;
                    }
                }
                else if (content[index] == '}')
                {
                    return index + 1;
                }
                else
                {
                    index++;
                }
            }

            return index;
        }
    }
    }