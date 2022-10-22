using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class HeroLog : ILog
    {
        public readonly Random random = new();
        public void Attack()
        {
            string[] arg = new string[5];
            arg[0] = "I have to destroy this monster";
            arg[1] = "it looks scary";
            arg[2] = "this place is so dark";
            arg[3] = "the monster is screaming";
            arg[4] = "can i kill it?";
            Console.WriteLine(arg[random.Next(0, 5)]);
        }
        public void Defeat()
        {
            string[] arg = new string[5];
            arg[0] = "Can only hope for the next resurrection";
            arg[1] = " Defeated, the monster is strong";
            arg[2] = "Need to buy more equipment";
            arg[3] = "If only I could do better";
            arg[4] = "The smile is gone";
            Console.WriteLine(arg[random.Next(0, 5)]);
        }
    }
}
