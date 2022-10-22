using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{    
    internal class Monster 
    {
        private string _name;
        private string _description;
        private double _damagePerHit;
        private double _attackSpeed;
        private double _health;
        private double _maxHealth;
        private double _movementSpeed;
        private double _gold;
        private readonly ILog monsterLog = new MonsterLog();
        public ILog MonsterLog()
        {
            return monsterLog;
        }
        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double DamagePerHit { get { return _damagePerHit; } set { _damagePerHit = value; } }
        public double AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value;} }
        public double Health { get { return _health; } set { _health = value; } }  
        public double MaxHealth { get { return _maxHealth; } set { _maxHealth = value;} }
        public double MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value;} }
        public double Gold { get { return _gold; } set { _gold = value; } }

        public Monster( string name, string description, double damagePerHit, double attackSpeed, double health, double maxHealth, double movementSpeed, double gold)
        {
            _name = name;
            _description = description;
            _damagePerHit = damagePerHit;
            _attackSpeed = attackSpeed;
            _health = health;
            _maxHealth = maxHealth;
            _movementSpeed = movementSpeed;
            _gold = gold;
        }
       
    }
}
