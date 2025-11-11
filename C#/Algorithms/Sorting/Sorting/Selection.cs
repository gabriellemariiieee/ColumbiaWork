using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Selection
    {
        public int[] Run(int[] list)
        {
            int[] result = list;
            for (int i = 0; i < result.Length; i++)
            {
                //finds minimun value of list
                int min = i;
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[j] < result[min])
                    {
                        min = j;
                    }
                }

                int temp = result[min];
                result[min] = result[i];
                result[i] = temp;
            }

            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }
            return result;
        }
    }
}
