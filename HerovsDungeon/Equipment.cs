using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal abstract class Equipment
    {
        private string _name;
        private string _description;
        private double _gold;
        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Gold { get { return _gold; } set { _gold = value; } }

        public Equipment(string name, string description, double gold)
        {
            _name = name;
            _description = description;
            _gold = gold;
        }
        public abstract void TypeInformation();
    }
}
