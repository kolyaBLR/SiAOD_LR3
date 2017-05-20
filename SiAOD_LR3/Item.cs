using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR3
{
    public class Item
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public Item Next { get; set; }
        public Item Back { get; set; }
    }
}