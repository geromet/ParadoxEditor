using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Reader
{
    public record Node
    {
        public string? Name { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public string? Value { get; set; }
        public List<string> Values { get; set; } = new List<string>();

    }
}
