using Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Linear
    {
        public int Run(int[] list, int x)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == x)
                {
                    Console.WriteLine(x + " was found at " + i);
                    return i;
                }
            }
            Console.WriteLine(x + "wasn't found.");
            return -1;
        }
    }
}
