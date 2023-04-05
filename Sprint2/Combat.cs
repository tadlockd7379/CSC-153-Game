using System;
using System.Threading;

namespace Sprint2
{
    class Combat
    {
        Random dice = new Random();

        Character player;
        Character enemy;

        public Combat(Character player, Character enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public Character Start()
        {
            Console.WriteLine("------ " + player.name + " vs. " + enemy.name + "------");
            Console.WriteLine("> " + player.name + " - HP: " + player.hp + ", ATK: " + player.atk);
            Console.WriteLine("> " + enemy.name + " - HP: " + enemy.hp + ", ATK: " + enemy.atk);
            Console.WriteLine(Utilities.Dashes(player.name.Length + enemy.name.Length + 18));

            while (player.hp > 0 && enemy.hp > 0)
            {
                Thread.Sleep(500);
                if (Move(player, enemy) == -1) return player;
                Thread.Sleep(500);
                if (Move(enemy, player) == -1 ) return enemy;
            }

            return player;
        }

        public double Move(Character attacker, Character victim)
        {
            double atk = Attack(attacker, victim);
            if (atk == -1)
            {
                Console.WriteLine(attacker.name + " killed " + victim.name + "!");
                return -1;
            }
            Console.WriteLine(attacker.name + " did " + atk + " damage to " + victim.name + " (" + victim.hp + "hp remaining)");
            return atk;
        }

        public double Attack(Character attacker, Character victim)
        {
            double damage = Damage(attacker);
            if (victim.hp - damage < 1)
            {
                damage = -1;
            }
            victim.hp -= damage;
            return damage;
        }

        public double Damage(Character attacker)
        {
            int roll = dice.Next(1, 12);
            double damage = attacker.atk + roll;
            return damage;
        }
    }
}
