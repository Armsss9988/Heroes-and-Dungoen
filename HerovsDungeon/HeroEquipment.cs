using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class HeroEquipment
    {
        private Head? _head;
        private Chest? _chest;
        private Leg? _leg;
        private Sword? _sword;
        private Bow? _bow;
        public Head? Head { get { return _head; } set { _head = value; } }
        public Chest? Chest { get { return _chest; } set { _chest = value; } }
        public Leg? Leg { get { return _leg; } set { _leg = value; } }
        public Sword? Sword { get { return _sword; } set { _sword = value; } }

        public Bow? Bow { get { return _bow; } set { _bow = value; } }


        public double ArmorTotal() 
        {
            double armorTotal = (this.Head?.ArmorAmount ?? 0 )+ (this.Chest?.ArmorAmount ?? 0)  + (this.Leg?.ArmorAmount ?? 0);
            return armorTotal;
        }
    }
}
