using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class Treasure : Item
    {
        public int amount;

        public Treasure(string name, string description, int amount) : base(name, description)
        {
            this.amount = amount;
        }
    }
}
