using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Binary
    {
        public int Run(int[] list, int x)
        {
            int[] result = list;

            //sorts data set using bubble sort
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 1; i < result.Length; i++)
                {
                    if (result[i] < result[i - 1])
                    {
                        int temp = result[i];
                        result[i] = result[i - 1];
                        result[i - 1] = temp;

                        notSorted = true;
                    }
                    else
                    {
                        continue;
                    }
                    continue;
                }
            }

            int left = 0, right = result.Length - 1;
            while (left <= right)
            {
                int m = left + (right - left) / 2;

                if (list[m] == x)
                {
                    Console.WriteLine(x + " was found at " + m);
                    return m;
                }

                if (result[m] < x)
                {
                    left = m + 1;
                }
                else
                {
                    right = m - 1;
                }
            }

            Console.WriteLine(x + " wasn't found.");
            return -1;
        }
    }
}
