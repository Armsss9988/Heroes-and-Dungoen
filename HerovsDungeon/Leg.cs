using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Leg : Armor
    {   
        public Leg(int armorAmount, string name, string description, double gold) : base(armorAmount, name, description, gold)
        {
        }
        public override void TypeInformation()
        {
            Console.WriteLine("put on the legs to reduce damage");
        }
    }
}
