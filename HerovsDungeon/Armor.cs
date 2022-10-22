using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal abstract class Armor : Equipment
    {
        public int ArmorAmount { get; set; }

        public Armor(int armorAmount, string name, string description, double gold) : base(name, description, gold)
        {
            ArmorAmount = armorAmount;
        }
    }
}
