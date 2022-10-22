using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Bow : Weapon
    {
        private double _range;
        public double Range { get { return _range; } set { _range = value; } }
        public Bow(string name, string description, double gold, int damage, int criticalHit, double attackSpeed, double range) 
            : base(name, description, gold, damage, criticalHit, attackSpeed)
        {
            Range = range;
        }

        public override void TypeInformation()
        {
            Console.WriteLine("Ranged weapons deal damage before monsters approach");
        }
    }
}
