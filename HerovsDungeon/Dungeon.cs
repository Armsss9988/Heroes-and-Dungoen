using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Dungeon
    {
        private string _name;
        private readonly List<Monster> _monsters = new();
        public string Name { get { return _name; } set { _name = value; } }
        public List<Monster> Monsters()
        {
            return _monsters;
        } 

        public Dungeon( string name)
        {
            _name = name;
        }   
        public void DisplayMonsters()
        {
            int i = 1;
            foreach (Monster monster in Monsters())
            {             
                Console.WriteLine("{0}. {1}", i, monster.Name);
                i++;
            }
        }
    }
}
