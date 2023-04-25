using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class Weapon : Item
    {
        public double damage;
        public int handedness;
        public string type;

        public Weapon(string name, string description, double damage, int handedness, string type) : base(name, description)
        {
            this.damage = damage;
            this.handedness = handedness;
            this.type = type;
        }
    }
}
