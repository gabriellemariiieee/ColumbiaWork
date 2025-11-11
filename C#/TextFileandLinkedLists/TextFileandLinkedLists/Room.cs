using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileandLinkedLists
{
    internal class Room
    {
        public int id;
        public Monster monster;
        public bool win;
        public Room(int ID, Monster m, bool w)
        {
            id = ID;
            monster = m;
            win = w;
        }
    }
}
