using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Head : Armor
    {
        public Head(int armorAmount, string name, string description, double gold) : base(armorAmount, name, description, gold)
        {
        }
        public override void TypeInformation()
        {
            Console.WriteLine("put on the head to reduce damage");
        }
    }
}
