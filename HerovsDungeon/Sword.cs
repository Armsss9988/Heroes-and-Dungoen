using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Sword : Weapon
    {
        private int _lifeSteal;
        public int LifeSteal { get { return _lifeSteal; } set { _lifeSteal = value; } }
        public Sword(string name, string description, double gold, int damage, int criticalHit, double attackSpeed, int lifeSteal)
            :base(name, description, gold, damage, criticalHit, attackSpeed)
        {
            LifeSteal = lifeSteal;
        }
        public override void TypeInformation()
        {
            Console.WriteLine("Melee weapons deal damage after monsters approach and can be steal monster's life");
        }
    }
}
