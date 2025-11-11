using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Bubble
    {
        public int[] Run(int[] ints)
        {
            int[] result = ints;
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for(int i = 1;  i < result.Length; i++)
                {
                    if (ints[i] < ints[i - 1])
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

            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }
            return result;
        }
    }
}
