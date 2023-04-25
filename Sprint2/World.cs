using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sprint2
{
    class World
    {
        public static Dictionary<string, string> keywords = new Dictionary<string, string>();
        public static List<Room> rooms = new List<Room>(); // couldn't use arrays for these since I'd have to add to them later, might even switch these to dictionaries
        public static List<Weapon> weapons = new List<Weapon>();
        public static List<Potion> potions = new List<Potion>();
        public static List<Treasure> treasure = new List<Treasure>();
        public static List<Item> items = new List<Item>();
        public static List<Character> mobs = new List<Character>();

        public static string[] roomsArray = { "Entrance", "Mob Room", "Mob Room", "Treasure Room", "Mob Room", "Boss Room" };

        public World()
        {
            Variables();
        }

        public void Variables()
        {
            // rooms
            JObject value = FormVariables("rooms");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                rooms.Add(new Room(key, x.Value.ToString()));
                keywords.Add(key, "Room, " + x.Value.ToString());
            }

            string roomNames = "";
            foreach (var x in rooms)
            {
                roomNames += x.name + ". ";
            }
            keywords.Add("rooms", roomNames);
            //

            // weapons
            value = FormVariables("weapons");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                double damage = double.Parse(x.Value.SelectToken("damage").ToString());
                int handedness = int.Parse(x.Value.SelectToken("handedness").ToString());
                string type = x.Value.SelectToken("type").ToString();

                weapons.Add(new Weapon(key, "weapon", damage, handedness, type));
                keywords.Add(key, handedness + " handed " + type + " weapon " + "doing " + damage + " damage.");
            }

            string weaponNames = "";
            foreach (var x in weapons)
            {
                weaponNames += x.name + ". ";

            }
            keywords.Add("weapons", weaponNames);
            //

            // potions
            value = FormVariables("potions");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                string description = x.Value.SelectToken("description").ToString();
                int uses = int.Parse(x.Value.SelectToken("uses").ToString());

                potions.Add(new Potion(key, description, uses));
                keywords.Add(key, key + " Potion, " + description + " with " + uses + " uses");
            }

            string potionNames = "";
            foreach (var x in potions)
            {
                potionNames += x.name + ". ";

            }
            keywords.Add("potions", potionNames);

            //

            // treasure
            value = FormVariables("treasure");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                string description = x.Value.SelectToken("description").ToString();
                int count = int.Parse(x.Value.SelectToken("count").ToString());

                treasure.Add(new Treasure(key, description, count));
                keywords.Add(key, key + " Treasure, " + description);
            }

            string treasureNames = "";
            foreach (var x in treasure)
            {
                treasureNames += x.name + ". ";
            }
            keywords.Add("treasure", treasureNames);
            //

            // items
            value = FormVariables("items");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                string description = x.Value.SelectToken("description").ToString();
                int count = int.Parse(x.Value.SelectToken("count").ToString());

                items.Add(new Item(key, description, count));
                keywords.Add(key, key + " Item, " + description);
            }

            string itemNames = "";
            foreach (var x in items)
            {
                itemNames += x.name + ". ";
            }
            keywords.Add("items", itemNames);
            //

            // mobs
            value = FormVariables("mobs");
            foreach (var x in value)
            {
                string key = x.Key.ToLower();
                double maxHp = double.Parse(x.Value.SelectToken("hp").ToString());
                double atk = double.Parse(x.Value.SelectToken("damage").ToString());

                mobs.Add(new Character(key, maxHp, atk));
                keywords.Add(key, key + " Mob with " + maxHp + " hp and " + atk + " attack damage.");
            }

            string mobNames = "";
            foreach (var x in mobs)
            {
                mobNames += x.name + ". ";
            }
            keywords.Add("mobs", mobNames);
            //

            string keywordNames = "keywords. ";
            foreach (string v in keywords.Keys)
            {
                keywordNames += v + ". ";
            }
            keywords.Add("keywords", keywordNames);

            Console.WriteLine("Registered " + keywords.Count + " keywords.");
        }

        public static JObject FormVariables(string file)
        {
            using (StreamReader stream = File.OpenText("./variables/" + file + ".json"))
            using (JsonTextReader reader = new JsonTextReader(stream))
            {
                return (JObject) JToken.ReadFrom(reader);
            }
        }
    }
}
