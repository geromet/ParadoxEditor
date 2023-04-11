using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            string input = @"
        MLO_ideas = {
            start = {
                infantry_power = 0.10
                diplomatic_upkeep = 1
            }

            bonus = {
                global_manpower_modifier = 0.20
            }

            trigger = {
                tag = MLO
            }
            free = yes

            renaissance_prince = {
                idea_cost = -0.1
            }
            graphical_culture = westerngfx

            color = { 157  51  167 }

            revolutionary_colors = { 8 1 8 }

            historical_idea_groups = {
                defensive_ideas
                offensive_ideas
                religious_ideas
            }
            monarch_names =
            {
                ""Friedrich #0"" = 100
                ""Ludwig #2"" = 80
                ""Ruprecht #2"" = 20
            }
        }
        "; // Your input string goes here.

            Parser parser = new Parser(input);
            Node root = parser.Parse();
            Console.WriteLine(root.ToString());
        }
    }
}

