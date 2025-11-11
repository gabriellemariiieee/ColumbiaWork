using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigONotation
{
    internal class BigO
    {
        public void Start()
        {
            getIntial("Stacy");
            string[] roster = { "Logan", "Kendall", "James", "Carlos", "Katie", "Camille", "Jo", "Jennifer", "Jet" };
            getClassRosterInitial(roster);
            string[] tens = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            countTo99(tens);
        }

        //O(1) as it always outputs the first Char in the given string
        void getIntial(string name)
        {
            Console.WriteLine(name.ElementAt(0));
        }

        //O(n) as it goes through each name in the given array to get the intial
        void getClassRosterInitial(string[] r)
        {
            foreach(string item in r)
            {
                Console.WriteLine(item.ElementAt(0));
            }
        }

        //O(n^2) as it gets the first nth value from the array and pairs it with the second nth value until it goes through the entire array
        void countTo99(string[] g)
        {
            foreach(string item in g)
            {
                foreach (string item2 in g)
                {
                    Console.WriteLine(item + item2);
                }
            }
        }
    }
}
