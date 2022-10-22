using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class Menu
    {
        public static void MenuMain(Town town)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Hero vs Dungeon");
                    Console.WriteLine("1. Choose hero");
                    Console.WriteLine("2. Create new hero");
                    Console.WriteLine("3. Chase hero");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter key:");
                    int key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            if (town.ListOfHeroes().Count > 0)
                            {
                                town.DisplayHeroes();
                                Console.WriteLine("Enter Hero Choose: ");
                                int heroIndex = int.Parse(Console.ReadLine()) - 1;
                                Hero heroPlay = town.ListOfHeroes()[heroIndex];
                                PlayMenu(town, heroPlay);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No hero in town!");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            Console.WriteLine("Enter hero's name: ");
                            string heroName = Console.ReadLine();
                            Hero heroNew = new(heroName);
                            town.ListOfHeroes().Add(heroNew);
                            break;
                        case 3:
                            if (town.ListOfHeroes().Count > 0)
                            {
                                town.DisplayHeroes();
                                Console.WriteLine("Choose hero number to delete:");
                                int heroIndex = int.Parse(Console.ReadLine()) - 1;
                                if (!(heroIndex >= 0 && heroIndex <= town.ListOfHeroes().Count - 1))
                                {
                                    Console.WriteLine("No hero found!!!");
                                    break;
                                }
                                else
                                {
                                    Hero heroChase = town.ListOfHeroes()[heroIndex];
                                    town.ListOfHeroes().Remove(heroChase);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hero in town!");
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid!!");
                            break;
                    }
                }catch (Exception)
                {
                    Console.WriteLine("Invalid!!!");
                    Console.ReadKey();
                }
            }
        }
        public static void PlayMenu(Town town, Hero heroPlay)
        {
            bool key = true;
            while (key)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("======================");
                    Console.WriteLine("1. Go dungeon");
                    Console.WriteLine("2. Shop");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("======================");
                    heroPlay.HeroInformation();
                    Console.Write("Enter key:");
                    int key1 = int.Parse(Console.ReadLine());
                    switch (key1)
                    {
                        case 1:
                            bool key11 = true;
                            while (key11)
                            {
                                Console.Clear();
                                Console.WriteLine("======================");
                                town.DisplayDungeon();
                                Console.WriteLine(town.ListOfDungeon().Count + 1 + ". Back");
                                Console.WriteLine("======================");
                                heroPlay.HeroInformation();
                                Console.WriteLine("Choose Dungeon: ");
                                int dungeonIndex = int.Parse(Console.ReadLine()) - 1;
                                if (dungeonIndex == town.ListOfDungeon().Count )
                                {
                                    key11 = false;
                                    break;
                                }
                                else
                                {
                                    bool key12 = true;
                                    while (key12)
                                    {
                                        Console.Clear();
                                        Dungeon dungeonChoose = town.ListOfDungeon()[dungeonIndex];
                                        Console.WriteLine("======================");
                                        dungeonChoose.DisplayMonsters();
                                        Console.WriteLine(dungeonChoose.Monsters().Count + 1 + ". Back");
                                        Console.WriteLine("======================");
                                        heroPlay.HeroInformation();
                                        Console.WriteLine("Choose Monster ");
                                        int monsterIndex = int.Parse(Console.ReadLine()) - 1;
                                        if (monsterIndex == dungeonChoose.Monsters().Count)
                                        {
                                            key12 = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            heroPlay.HeroInformation();
                                            Monster monsterChoose = dungeonChoose.Monsters()[monsterIndex];
                                            Console.WriteLine("Fighting!!!!");
                                            heroPlay.Fighting(monsterChoose);
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                }
                            }
                            break;

                        case 2:
                            town._shop.DisplayShop(heroPlay);
                            break;
                        case 3:
                            key = false;
                            break;

                        default:
                            Console.WriteLine("Invalid!!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid");
                    Console.ReadKey();
                }
            }
           
        }
        






       
            
    
        
    }
}
