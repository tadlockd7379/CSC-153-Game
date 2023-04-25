/**
* Date
* CSC 153
* Drew Tadlock
* Create a menu to display some rooms, weapons, potion, treasures, items, mobs, and an exit
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using Sprint2;

namespace Sprint_2
{

    class Program
    {
        static int currentRoom = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to game!");
            new World();

            Input();
            //FormVariables();

            //Menu("showOptions");
        }

        static void Input()
        {
            Console.Write("Input (\"Keywords\"/\"North\"/\"South\"/\"Weapons\"/\"Spear\"/etc.): ");
            string input = Console.ReadLine().ToLower();

            if (input == "north" || input == "n")
            {
                if (currentRoom == World.roomsArray.Length - 1)
                {
                    Console.WriteLine("You've already reached the final room.");
                }
                else
                {
                    currentRoom++;
                    Console.WriteLine(World.roomsArray[currentRoom]);
                }
            }
            else if (input == "south" || input == "s")
            {
                if (currentRoom == 0)
                {
                    Console.WriteLine("You're already at the first room");
                }
                else
                {
                    currentRoom--;
                    Console.WriteLine(World.roomsArray[currentRoom]);
                }
            }
            else
            {
                if (World.keywords.ContainsKey(input))
                {
                    World.keywords.TryGetValue(input, out string response);
                    Console.WriteLine(response);
                }
                else
                {
                    Console.WriteLine("Unknown Input!");
                }
            }


            Input();
        }
    }
}

        /*
        void Menu(string option)
        {
            if (option == "showOptions")
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Options");
                Console.WriteLine("----------------");
                Console.WriteLine("> Combat"); // temporary combat demo
                Console.WriteLine("> Rooms");
                Console.WriteLine("> Weapons");
                Console.WriteLine("> Potions");
                Console.WriteLine("> Treasure");
                Console.WriteLine("> Items");
                Console.WriteLine("> Mobs");
                Console.WriteLine("> Exit");
                Console.WriteLine("----------------");
            }

            string choice = Console.ReadLine();

            if (choice == "Combat") // temporary combat demo
            {
                Character player = new Character("Player", 100, 5);
                Character enemy = new Character("Enemy", 100, 5);
                Combat combat = new Combat(player, enemy);
                combat.Start();
                Menu("showOptions");
            }

            bool input = MenuInput(choice);
            if (input == false)
            {
                Console.WriteLine("Invalid Option!");
                Menu("showOptions");
            }
        }

        bool MenuInput(string input)
        {
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting!");
                Environment.Exit(0);
            }

            JToken submenu = variables.GetValue(input);
            if (submenu != null)
            {
                SubMenu(submenu, "showOptions");
            }
            else
            {
                return false;
            }

            return true;
        }

        bool SubMenu(JToken token, string options)
        {
            if (options == "showOptions")
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Options");
                Console.WriteLine("----------------");
                foreach (JToken pair in token)
                {
                    Console.WriteLine("> " + pair.Path);
                }
                Console.WriteLine("> Back");
                Console.WriteLine("> Exit");
                Console.WriteLine("----------------");
            }
            string choice = Console.ReadLine();
            bool input = SubMenuInput(token, choice);
            if (input == false)
            {
                SubMenu(token, "showOptions");
            }

            return true;
        }

        static bool SubMenuInput(JToken token, string input)
        {
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting!");
                Environment.Exit(0);
            }
            else if (input.ToLower() == "back")
            {
                Menu("showOptions");
                return true;
            }
            else
            {
                var value = token.Value<dynamic>(input);
                if (value != null)
                {
                    Console.WriteLine("------ " + input + "-----");
                    Console.WriteLine(value);
                    Console.WriteLine("------ " + input + "------");
                    SubMenu(token, "");
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
        */