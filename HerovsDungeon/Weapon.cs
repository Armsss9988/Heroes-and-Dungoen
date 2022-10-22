using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal abstract class Weapon : Equipment
    {
        private int _damage;
        private int _criticalHit;
        private double _attackSpeed;
        public int Damage { get { return _damage; } set { _damage = value; } }
        public int CriticalHit { get { return _criticalHit; } set { _criticalHit = value;} }
        public double AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value;} }
    
        public Weapon(string name, string description, double gold, int damage, int criticalHit, double attackSpeed):base(name, description, gold)
        {
            _damage = damage;
            _criticalHit = criticalHit;
            _attackSpeed = attackSpeed;
        }
    }
}
