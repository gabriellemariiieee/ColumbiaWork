using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Interpolation
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

                search(list, 0, result.Length - 1, x);
            }

            
            return x;
        }

        private int search(int[] list, int low, int high, int x)
        {
            int pos;
            if (low <= high && x >= list[low] && x <= list[high])
            {
                pos = low + (((high-low) / (list[high] - list[low])) * (x - list[low]));
                if (list[pos] == x)
                {
                    Console.WriteLine(x + " was found at " +  pos);
                    return pos;
                } 
                else if (list[pos] < x)
                {
                    return search(list, pos + 1, high, x);
                }
                else
                {
                    return search(list, low, pos - 1, x);
                }
            }

            Console.WriteLine(x + " wasn't found.");
            return -1;
        }
    }
}
