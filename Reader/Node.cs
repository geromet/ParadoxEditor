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
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public string? Value { get; set; }

        [NotMapped]
        public List<string> Values { get; set; } = new List<string>();

        public string? ValueArrayJson { get; set; }

        [NotMapped]
        public string[] ValueArray
        {
            get => ValueArrayJson == null ? null : JsonSerializer.Deserialize<string[]>(ValueArrayJson);
            set => ValueArrayJson = JsonSerializer.Serialize(value);
        }
    }
}
