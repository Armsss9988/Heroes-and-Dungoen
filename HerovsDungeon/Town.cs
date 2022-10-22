using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Town
    {
        private string _name;
        private readonly List<Dungeon> _dungeons = new();
        private readonly List<Hero> _heroes = new();
        public Shop _shop = Shop.GetShop();
        public List<Dungeon> ListOfDungeon()
        {
            return _dungeons;
        }
        public List<Hero> ListOfHeroes()
        {
            return _heroes;
        }

        public string Name { get { return _name; } set { _name = value; } }

        public Town(string Name)
        {
            this.Name = Name;
        }

        public void DisplayHeroes()
        {
            int i = 1;
            foreach(Hero hero in _heroes)
            {
                Console.WriteLine(i + ". " + hero.Name);
                i++;
            }
        }
        public void DisplayDungeon()
        {
            int i = 1;
            foreach (Dungeon dungeon in _dungeons)
            {
                Console.WriteLine(i + ". " + dungeon.Name);
                i++;
            }
        }

    }
    
}
