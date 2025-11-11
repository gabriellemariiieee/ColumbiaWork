using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileandLinkedLists
{
    internal class Monster
    {
        string Type { get; set; }
        int HP { get; set; }
        int MP { get; set; }
        int AP { get; set; }
        int DEF { get; set; }

        public string type;
        public int hp, mp, ap, def;

        public Monster() { }

        Monster (string type, int hP, int mP, int aP, int dEF)
        {
            Type = type;
            HP = hP;
            MP = mP;
            AP = aP;
            DEF = dEF;
        }
    }
}
