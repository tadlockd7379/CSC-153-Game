using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class Item
    {
        public string name;
        public string description;

        public Item(string name, string description, int count = 1)
        {
            this.name = name;
            this.description = description;
        }
    }
}
