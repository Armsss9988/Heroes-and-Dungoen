using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Hero 
    {
        private string _name;
        private double _baseDamagePerHit;
        private double _baseAttackSpeed;
        private double _baseCritical;
        private double _health;
        private double _maxHealth;
        private double _gold;
        private readonly ILog heroLog = new HeroLog();

        private readonly HeroEquipment _equipment = new();
        public string Name { get { return _name; } set { _name = value; } }
        public double BaseDamagePerHit { get { return _baseDamagePerHit; } set { _baseDamagePerHit = value; } }
        public double BaseAttackSpeed { get { return _baseAttackSpeed; } set { _baseAttackSpeed = value; } }
        public double BaseCritical { get { return _baseCritical; } set { _baseCritical = value; } }
        public double Health { get { return _health; } set { _health = value; } }
        public double MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        public double Gold { get { return _gold; } set { _gold = value; } }
        public HeroEquipment GetEquipment()
        {
            return _equipment;
        }

        public Hero(string name, double baseDamagePerHit, double baseAttackSpeed, double health, double maxHealth)
        {
            _name = name;
            _baseDamagePerHit = baseDamagePerHit;
            _baseAttackSpeed = baseAttackSpeed;
            _health = health;
            _maxHealth = maxHealth;
        }
        public Hero(string name)
        {
            _name = name;
            _baseDamagePerHit = 20;
            _baseAttackSpeed = 0.3;
            _baseCritical = 10;
            _health = 150;
            _maxHealth = 150;
            _gold = 1500;
        }
        public double MeleeCritical()
        {
            double meleeCritical = _baseCritical + (_equipment.Sword?.CriticalHit ?? 0);
            return meleeCritical;
        }
        public double RangeCritical()
        {
            double rangeCritical = _baseCritical + (_equipment.Bow?.CriticalHit ?? 0);
            return rangeCritical;
        }
        public double MeleeDamage()
        {
            double meleeDamage = _baseDamagePerHit + (_equipment.Sword?.Damage ?? 0);

            return meleeDamage;
        }
        public double RangeDamage()
        {
            double rangeDamage = _equipment.Bow?.Damage ?? 0;
            return rangeDamage;
        }
        public int LifeSteal()
        {
            int lifeSteal = _equipment.Sword?.LifeSteal ?? 0;
            return lifeSteal;
        }
        public double Range()
        {
            double range = _equipment.Bow?.Range ?? 0;
            return range;
        }
        public double MeleeAttackSpeed()
        {
            double meleeAttackSpeed = _baseAttackSpeed + _baseAttackSpeed*(_equipment.Sword?.AttackSpeed ?? 0)/100;
            return meleeAttackSpeed;
        }
        public double RangeAttackSpeed()
        {                      
            double rangeAttackSpeed = _baseAttackSpeed + _baseAttackSpeed*(_equipment.Bow?.AttackSpeed ?? 0)/100;
            return rangeAttackSpeed;           
        }
        public void HeroInformation()
        {
            StringBuilder equipmentInformation = new();
            equipmentInformation.AppendLine("                        Hero: " + Name);
            equipmentInformation.AppendLine("============================================================");
            equipmentInformation.AppendLine("HERO INFORMATION");
            equipmentInformation.AppendLine("Head: " + (GetEquipment().Head?.Name ?? "none"));
            equipmentInformation.AppendLine("Chest: " + (GetEquipment().Chest?.Name ?? "none"));
            equipmentInformation.AppendLine("Leg: " + (GetEquipment().Leg?.Name ?? "none"));
            equipmentInformation.AppendLine("Melee Weapon: " + (GetEquipment().Sword?.Name  ?? "none"));
            equipmentInformation.AppendLine("Range Weapon: " + (GetEquipment().Bow?.Name ?? "none"));
            equipmentInformation.AppendFormat("{0, 25}   {1, 25}", "Armor amount: " + GetEquipment().ArmorTotal(), "LifeSteal: " + LifeSteal());
            equipmentInformation.AppendLine("");
            equipmentInformation.AppendFormat("{0, 25}   {1, 25}","Melee attack speed: " + MeleeAttackSpeed().ToString("F"), "Range attack speed: " +  RangeAttackSpeed().ToString("F"));
            equipmentInformation.AppendLine("");
            equipmentInformation.AppendFormat("{0, 25}   {1, 25}","Melle Damage: " + MeleeDamage(),"Range damage: " +RangeDamage());
            equipmentInformation.AppendLine("");
            equipmentInformation.AppendFormat("{0, 25}   {1, 25}","Melle critical rate: " + MeleeCritical(), "Range critical rate: " + RangeCritical());
            equipmentInformation.AppendLine("");
            equipmentInformation.AppendLine("Gold: " + Gold);
            equipmentInformation.Append("===============================================================");
            Console.WriteLine(equipmentInformation.ToString());
        }

        public void Fighting(Monster monster)
        {
            Console.WriteLine("{0, 110}", Name + ": " + Health + "/" + MaxHealth + " vs " + monster.Name + ": " + monster.Health + "/" + monster.MaxHealth);
            double range = Range();
            Random critical = new();
            if(range > 0 && monster.Health > 0)
            {
                Console.WriteLine("hero {0} use bow to shot {1} ", Name, monster.Name);
            }
            while (range > 0 && monster.Health > 0)
            {
                
                Console.Write("{0, 20}", "Hero attack monster ");

                if (critical.Next(0, 100) <= RangeCritical())
                {
                    Console.Write("{0, 20}","Critical!");
                    monster.Health -= (RangeDamage() * 2);
                    Console.Write("{0, 20}"," deal " + (RangeDamage() * 2) + " damage");
                }
                else
                {
                    monster.Health -= RangeDamage();
                    Console.Write("{0, 40}","Hero deal " + RangeDamage() + " damage");
                }
                range -= (monster.MovementSpeed / RangeAttackSpeed());
                if (monster.Health <= 0)
                {
                    monster.Health = 0;
                }
                Console.WriteLine("{0, 50}", Name + ": " + Health + "/" + MaxHealth + " vs " + monster.Name + ": " + monster.Health + "/" + monster.MaxHealth);
                heroLog.Attack();
                Console.ReadKey();
            }
            if (range <= 0 && monster.Health > 0)
            {
                Console.WriteLine("Monster approach hero. They started to fight hand to hand");
                
            }
            double monsterTurn = monster.AttackSpeed;
            double heroTurn = MeleeAttackSpeed();
            while (range <= 0 && monster.Health > 0 && Health > 0)
            {               
               
                if (heroTurn >= monsterTurn)
                {
                    Console.Write("{0, 20}", "Hero attack monster ");
                    if (critical.Next(0, 100) <= MeleeCritical())
                    {
                        Console.Write("{0, 20}", "Critical!");
                        monster.Health -=  (MeleeDamage());
                        Console.Write("{0, 20}", " deal " + (MeleeDamage() * 2) + " damage");
                        double lifeHealing = MeleeDamage() * 2 * LifeSteal() / 100;
                        Console.Write("{0,10}", "Heal: " + (int)lifeHealing);
                        if (Health < MaxHealth)
                        {   
                            Health += (int) lifeHealing;
                        }
                        if (Health > MaxHealth)
                        {
                            Health = MaxHealth;
                        }
                        if (monster.Health <= 0)
                    {
                        monster.Health = 0;
                    }

                    }
                    else
                    {
                        monster.Health -= MeleeDamage();
                        Console.Write("{0, 40}", "Hero deal " + MeleeDamage() + " damage");
                        double lifeHealing = MeleeDamage() * LifeSteal() / 100;
                        Console.Write("{0,10}", "Heal: " + (int)lifeHealing);
                        if (Health < MaxHealth)
                        {
                            Health += (int) lifeHealing;
                        }
                        if (Health > MaxHealth)
                        {
                            Health = MaxHealth;
                        }
                    }
                    monsterTurn += monster.AttackSpeed;
                    if (monster.Health <= 0)
                    {
                        monster.Health = 0;
                    }
                        Console.WriteLine("{0, 40}", Name + ": " + Health + "/" + MaxHealth + " vs " + monster.Name + ": " + monster.Health + "/" + monster.MaxHealth);

                    heroLog.Attack();

                }
                else
                {
                    
                    Console.Write("{0, 20}","Monster attack Hero");
                    double monsterDamage = monster.DamagePerHit*(100/(100+GetEquipment().ArmorTotal()));
                    Console.Write("{0, 50}","Monster deal " + (int) monsterDamage + " damage");
                    Health -= (int) monsterDamage;
                    heroTurn += MeleeAttackSpeed();
                    if (_health <= 0)
                    {
                        _health = 0;
                    }
                        Console.WriteLine("{0, 40}", Name + ": " + Health + "/" + MaxHealth + " vs " + monster.Name + ": " + monster.Health + "/" + monster.MaxHealth);

                    monster.MonsterLog().Attack();
                    
                }
                 Console.ReadKey();
            }
            if (monster.Health == 0)
            {
                monster.Health = 0;
                Console.WriteLine("Monster defeated!!! Gain {0} gold", monster.Gold);
                monster.MonsterLog().Defeat();
                Gold += monster.Gold;
            }
            if (_health == 0)
            {
                _health = 0;
                Console.WriteLine("Hero defeated, Lost 10 gold");
                heroLog.Defeat();
                Gold -= 10;
            }
            Health = MaxHealth;
            monster.Health = monster.MaxHealth;

        }

    }
}
