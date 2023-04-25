using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class Potion : Item
    {
        public int uses;

        public Potion(string name, string description, int uses) : base(name, description)
        {
            this.uses = uses;
        }
    }
}
