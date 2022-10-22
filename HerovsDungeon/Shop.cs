using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Shop
    {
        private readonly List<Head> headGears = new();
        private readonly List<Chest> chestGears = new();
        private readonly List<Leg> legGears = new();
        private readonly List<Sword> swords = new();
        private readonly List<Bow> bows = new();
        private static Shop shop;
        private Shop() { }
        public static Shop GetShop()
        {
            if (shop == null)
            {
                shop = new Shop();
            }
            return shop;
        }
        public List<Head> Headgears()
        {
            return headGears;
        }
        public List<Chest> ChestGears()
        {
            return chestGears;
        }
        public List<Leg> Leggears()
        {
            return legGears;
        }
        public List<Sword> Swords()
        {
            return swords;
        }
        public List<Bow> Bows()
        {
            return bows;
        }
        public void DisplayHeadGear()
        {
            Console.WriteLine("Headgear");
            headGears[0].TypeInformation();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("{0, 3}||   {1, 20}     ||{2, 15}     ||{3, 15}", "No", "Name", "Armor", "Price");
            Console.WriteLine("=========================================================================");
            int i = 1;
            foreach (Head head in headGears)
            {

                Console.WriteLine("=========================================================================");
                Console.WriteLine("{0, 3}||   {1, 20}     ||{2, 15}     ||{3, 15}" ,i, head.Name, head.ArmorAmount, head.Gold);
                Console.WriteLine("Description: " + head.Description );
                Console.WriteLine("=========================================================================");
                i++;
            }
        }
        public void DisplayChestGear()
        {
            int i = 1;
            Console.WriteLine("Chestgear");
            chestGears[0].TypeInformation();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("{0, 3}||     {1, 20}     ||{2, 15}     ||{3, 15}", "No", "Name", "Armor", "Price");
            Console.WriteLine("=========================================================================");
            foreach (Chest chest in chestGears)
            {
                Console.WriteLine("=========================================================================");
                Console.WriteLine("{0, 3}||   {1, 20}     ||{2, 15}     ||{3, 15}", i, chest.Name, chest.ArmorAmount, chest.Gold);
                Console.WriteLine("Description: " + chest.Description);
                Console.WriteLine("=========================================================================");
                i++;
            }
        }
        public void DisplayLegGear()
        {
            Console.WriteLine("Legsgear");
            legGears[0].TypeInformation();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("{0, 3}||   {1, 20}     ||{2, 15}     ||{3, 15}", "No", "Name", "Armor", "Price");
            Console.WriteLine("=========================================================================");
            int i = 1;
            foreach (Leg leg in legGears)
            {
                Console.WriteLine("=========================================================================");
                Console.WriteLine("{0, 3}||   {1, 20}     ||{2, 15}     ||{3, 15}", i, leg.Name, leg.ArmorAmount, leg.Gold);
                Console.WriteLine("Description: " + leg.Description);
                Console.WriteLine("=======================================================================================");
                i++;
            }
        }
        public void DisplaySwords()
        {
            int i = 1;
            swords[0].TypeInformation();
            Console.WriteLine("Swords");
            Console.WriteLine("=====================================================================================================================");
            Console.WriteLine("{0, 3} ||{1, 20}    ||{2, 8}    ||{3, 15}    ||{4, 10}    ||{5, 8}    ||{6, 10}", "No"," Sword Name", "Damage", "Attack Speed", "LifeSteal", "Price", "Critical");
            Console.WriteLine("=====================================================================================================================");
            foreach (Sword sword in swords)
            {
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("{0, 3} ||{1, 20}    ||{2, 8}    ||{3, 15}    ||{4, 10}    ||{5, 8}    ||{6, 10}", i, sword.Name, sword.Damage, sword.AttackSpeed + "%", sword.LifeSteal + "%", sword.Gold, sword.CriticalHit);
                Console.WriteLine("Description: " + sword.Description );
                Console.WriteLine("=====================================================================================================================");
                i++;
            }
        }
        public void DisplayBows()
        {
            int i = 1;
            Console.WriteLine("Bows");
            bows[0].TypeInformation();
            Console.WriteLine("=====================================================================================================================");
            Console.WriteLine("{0, 3}     ||{1, 20}     ||{2, 8}     ||{3, 15}     ||{4, 8}     ||{5, 8}    ||{6, 10}", "No", "Name", "Damage", "Attack Speed", "Range", "Price", "Critical");
            Console.WriteLine("=====================================================================================================================");
            foreach (Bow bow in bows)
            {
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("{0, 3}     ||{1, 20}     ||{2, 8}     ||{3, 15}     ||{4, 8}     ||{5, 8}    ||{6, 10}", i, bow.Name, bow.Damage, bow.AttackSpeed + "%", bow.Range, bow.Gold, bow.CriticalHit);
                Console.WriteLine("Description: " + bow.Description);
                Console.WriteLine("=====================================================================================================================");
                i++;
            }
        }
        public void DisplayShop(Hero hero)
        {
            bool keyloop = true;
            while (keyloop) 
            {
                Console.Clear();
                hero.HeroInformation();
                Console.WriteLine("Welcome to adventurer's shop!!");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. HeadGears");
                Console.WriteLine("2. ChestGears");
                Console.WriteLine("3. LegGears");
                Console.WriteLine("4. Swords");
                Console.WriteLine("5. Bows");
                Console.WriteLine("6. Exit");
                Console.WriteLine("===========================================");
                Console.WriteLine("Enter gear type number: ");
                try
                {
                    int key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            DisplayHeadGear();
                            int i1 = headGears.Count + 1;
                            Console.WriteLine(i1 + ". Back");
                            Console.WriteLine("Enter item to buy:");
                            int headGearIndex = int.Parse(Console.ReadLine()) - 1;
                            if (headGearIndex == i1 - 1)
                            {
                                break;
                            }
                            else
                            {
                                if (headGears[headGearIndex] != hero.GetEquipment().Head)
                                {
                                    if (headGears[headGearIndex].Gold <= hero.Gold)
                                    {
                                        hero.Gold -= headGears[headGearIndex].Gold;
                                        hero.GetEquipment().Head = headGears[headGearIndex];
                                        Console.WriteLine("Successful buy " + headGears[headGearIndex].Name);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money !");
                                        Console.ReadKey();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You already have");
                                    Console.ReadKey();
                                    break;
                                }
                            }

                        case 2:
                            DisplayChestGear();
                            int i2 = chestGears.Count + 1;
                            Console.WriteLine(i2 + ". Back");
                            Console.WriteLine("Enter item to buy:");
                            int chestGearIndex = int.Parse(Console.ReadLine()) - 1;
                            if (chestGearIndex == i2 - 1)
                            {
                                break;
                            }
                            else
                            {
                                if(chestGears[chestGearIndex] != hero.GetEquipment().Chest)
                                {
                                    if (headGears[chestGearIndex].Gold <= hero.Gold)
                                    {
                                        hero.Gold -= chestGears[chestGearIndex].Gold;
                                        hero.GetEquipment().Chest = chestGears[chestGearIndex];
                                        Console.WriteLine("Successful buy " + chestGears[chestGearIndex].Name);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money !");
                                        Console.ReadKey();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You already have");
                                    Console.ReadKey();
                                    break;

                                }
                            }
                        case 3:
                            DisplayLegGear();
                            int i3 = legGears.Count + 1;
                            Console.WriteLine(i3 + ". Back");
                            Console.WriteLine("Enter item to buy:");
                            int legGearIndex = int.Parse(Console.ReadLine()) - 1;
                            if (legGearIndex == i3 - 1)
                            {
                                break;
                            }
                            else
                            {
                                if (legGears[legGearIndex] != hero.GetEquipment().Leg)
                                {
                                    if (headGears[legGearIndex].Gold <= hero.Gold)
                                    {
                                        hero.Gold -= legGears[legGearIndex].Gold;
                                        hero.GetEquipment().Leg = legGears[legGearIndex];
                                        Console.WriteLine("Successful buy " + legGears[legGearIndex].Name);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money !");
                                        Console.ReadKey();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You already have");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        case 4:
                            DisplaySwords();
                            int i4 = swords.Count + 1;
                            Console.WriteLine(i4 + ". Back");
                            Console.WriteLine("Enter item to buy:");
                            int swordIndex = int.Parse(Console.ReadLine()) - 1;
                            if (swordIndex == i4 - 1)
                            {
                                break;
                            }
                            else
                            {
                                if (swords[swordIndex] != hero.GetEquipment().Sword)
                                {
                                    if (headGears[swordIndex].Gold <= hero.Gold)
                                    {
                                        hero.Gold -= swords[swordIndex].Gold;
                                        hero.GetEquipment().Sword = swords[swordIndex];
                                        Console.WriteLine("Successful buy " + swords[swordIndex].Name);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money !");
                                        Console.ReadKey();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You already have");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        case 5:
                            DisplayBows();
                            int i5 = swords.Count + 1;
                            Console.WriteLine(i5 + ". Back");
                            Console.WriteLine("Enter item to buy: ");
                            int bowIndex = int.Parse(Console.ReadLine()) - 1;
                            if (bowIndex == i5 - 1)
                            {
                                break;
                            }
                            else
                            {
                                if(bows[bowIndex] != hero.GetEquipment().Bow)
                                {
                                    if (bows[bowIndex].Gold <= hero.Gold)
                                    {
                                        hero.Gold -= bows[bowIndex].Gold;
                                        hero.GetEquipment().Bow = bows[bowIndex];
                                        Console.WriteLine("Successful buy " + bows[bowIndex].Name);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money !");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You already have");
                                    Console.ReadKey();
                                }
                                break;
                            }
                            
                        case 6:
                            keyloop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid key");
                            Console.ReadKey();
                            break;
                    }
                }                
                catch (Exception)
                {
                    Console.WriteLine("Invalid!!!");
                    Console.ReadKey();
                }
        }
            
            
        }
    }
}
            