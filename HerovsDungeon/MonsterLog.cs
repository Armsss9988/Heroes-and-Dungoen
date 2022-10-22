using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerovsDungeon
{
    internal class MonsterLog : ILog
    {
        readonly Random random = new();
        public void Attack()
        {
            string[] arg = new string[5];
            arg[0] = "You are as weak as a slug";
            arg[1] = "come on! stop crying";
            arg[2] = "You were only at home with your mother before?";
            arg[3] = "Eat this trick!";
            arg[4] = "Do you feel pain??";
            Console.WriteLine(arg[random.Next(0, 5)]);
        }
        public void Defeat()
        {
            string[] arg = new string[5];
            arg[0] = "Badluck today";
            arg[1] = "Here! Money here!!";
            arg[2] = "Just don't want to kill you";
            arg[3] = "99 monsters like me!!!";
            arg[4] = "The smile is gone";
            Console.WriteLine(arg[random.Next(0, 5)]);
        }
    }
}
