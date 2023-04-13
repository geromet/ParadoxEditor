using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class InputFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public Node RootNode { get; set; }
    }
}
